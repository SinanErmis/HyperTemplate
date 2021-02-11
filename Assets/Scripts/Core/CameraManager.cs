using System;
using System.Collections;
using DG.Tweening;
using MyBox;
using Rhodos.Toolkit.Extensions;
using UnityEngine;

namespace Rhodos.Core
{
    public class CameraManager : MonoBehaviour
    {
        public static Camera Camera { get; private set; }
        public static Transform CameraTransform { get; private set; }

        public void Awake()
        {
            Camera = Camera.main;
            CameraTransform = Camera.transform;
        }

        /// <summary>
        /// Linearly interpolates camera position.
        /// Spherically interpolates camera rotation.
        /// </summary>
        public static Sequence MoveCamera(Transform cameraPose, float duration)
        {
            return CameraTransform.DOMoveAndRotate(cameraPose, duration, false);
        }

        public static void SetCameraPose(Transform cameraPose)
        {
            CameraTransform.position = cameraPose.position;
            CameraTransform.rotation = cameraPose.rotation;
        }

        public static Matrix4x4 MatrixLerp(Matrix4x4 from, Matrix4x4 to, float time)
        {
            Matrix4x4 ret = new Matrix4x4();
            for (int i = 0; i < 16; i++)
                ret[i] = Mathf.Lerp(from[i], to[i], time);
            return ret;
        }

        public static IEnumerator LerpFromTo(Matrix4x4 src, Matrix4x4 dest, float duration)
        {
            float startTime = Time.time;
            while (Time.time - startTime < duration)
            {
                Camera.projectionMatrix = MatrixLerp(src, dest, (Time.time - startTime) / duration);
                yield return null;
            }

            Camera.projectionMatrix = dest;
            Camera.ResetProjectionMatrix();
        }

        public static IEnumerator SmoothOrtho(float size, float duration, Func<float, float> multiplier = null)
        {
            Matrix4x4 current = Camera.projectionMatrix;
            Matrix4x4 ortho = Matrix4x4.Ortho(-size * Camera.aspect, size * Camera.aspect, -size, size,
                Camera.nearClipPlane, Camera.farClipPlane);
            yield return LerpFromTo(current, ortho, duration * (multiplier?.Invoke(duration) ?? 1)).StartCoroutine();
            Camera.orthographicSize = size;
            Camera.orthographic = true;
            Camera.ResetProjectionMatrix();
        }

        public static IEnumerator SmoothPerspective(float fov, float duration, Func<float, float> multiplier = null)
        {
            Matrix4x4 current = Camera.projectionMatrix;
            Matrix4x4 perspective =
                Matrix4x4.Perspective(fov, Camera.aspect, Camera.nearClipPlane, Camera.farClipPlane);
            yield return LerpFromTo(current, perspective, duration * (multiplier?.Invoke(duration) ?? 1))
                .StartCoroutine();
            Camera.fieldOfView = fov;
            Camera.orthographic = false;
            Camera.ResetProjectionMatrix();
        }
    }
}
