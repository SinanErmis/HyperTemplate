using System;
using System.Collections;
using MyBox;
using Rhodos.Toolkit.Extensions;
using Toolkit;
using UnityEngine;

namespace Rhodos.Core
{
    public class CameraManager : SingletonBehaviour<CameraManager>
    {
        public static Camera Camera { get; private set; }
        public static Transform CameraTransform { get; private set; }

        private void Awake()
        {
            Camera = Camera.main;
            CameraTransform = Camera.transform;
        }

        public static void SetCameraPose(Transform cameraPose)
        {
            CameraTransform.position = cameraPose.position;
            CameraTransform.rotation = cameraPose.rotation;
        }
        
        private static IEnumerator LerpFromTo(Matrix4x4 src, Matrix4x4 dest, float duration)
        {
            float startTime = Time.time;
            while (Time.time - startTime < duration)
            {
                Camera.projectionMatrix = src.MatrixLerp(dest, (Time.time - startTime) / duration);
                yield return null;
            }

            Camera.projectionMatrix = dest;
            Camera.ResetProjectionMatrix();
        }

        public static IEnumerator SmoothOrtho(float size, float duration, Func<float, float> multiplier = null)
        {
            Matrix4x4 current = Camera.projectionMatrix;
            float aspect = Camera.aspect;
            Matrix4x4 ortho = Matrix4x4.Ortho(-size * aspect, size * aspect, -size, size,
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
        
        private bool _isCameraStopped;
        [ButtonMethod] private void StopCamera() => _isCameraStopped = true;
        public IEnumerator BindTargetTransform(Transform target, float speed, bool lerpRotation = true)
        {
            while (!_isCameraStopped)
            {
                yield return null;

                CameraTransform.position = Vector3.Lerp(CameraTransform.position, target.position, Time.deltaTime * speed);

                if (lerpRotation)
                {
                    CameraTransform.rotation = Quaternion.Lerp(CameraTransform.rotation, target.rotation,
                        Time.deltaTime * speed);
                }
            }
        }
    }
}
