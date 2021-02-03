using System.Collections;
using DG.Tweening;
using UnityEngine;
using MyBox;

namespace Rhodos.Toolkit.Extensions
{
    public static class DOTweenExtensions
    {
        public static Tween DORotateQuaternionSlerp(this Transform t, Vector3 target, float duration)
        {
            Quaternion start = t.rotation;
            Quaternion targetQ = Quaternion.Euler(target);
            float timer = 0f;
            return DOTween.To(()=>timer,(x)=>timer = x,duration,duration).OnUpdate(() =>
            {
                t.rotation = Quaternion.Slerp(start, targetQ, timer / duration);
            });
        }
        public static Tween DORotateQuaternionSlerp(this Transform t, Quaternion target, float duration)
        {
            Quaternion start = t.rotation;
            float timer = 0f;
            return DOTween.To(()=>timer,(x)=>timer = x,duration,duration).OnUpdate(() =>
            {
                t.rotation = Quaternion.Slerp(start, target, timer / duration);
            });
        }
        public static Tween DORotateQuaternionLerp(this Transform t, Vector3 target, float duration)
        {
            Quaternion start = t.rotation;
            Quaternion targetQ = Quaternion.Euler(target);
            float timer = 0f;
            return DOTween.To(()=>timer,(x)=>timer = x,duration,duration).OnUpdate(() =>
            {
                t.rotation = Quaternion.Lerp(start, targetQ, timer / duration);
            });
        }
        public static Tween DORotateQuaternionLerp(this Transform t, Quaternion target, float duration)
        {
            Quaternion start = t.rotation;
            float timer = 0f;
            return DOTween.To(()=>timer,(x)=>timer = x,duration,duration).OnUpdate(() =>
            {
                t.rotation = Quaternion.Lerp(start, target, timer / duration);
            });
        }

        /// <summary>
        /// Makes DOMove and DORotate at the same time
        /// </summary>
        /// <param name="transform">Transform that tween will be played on</param>
        /// <param name="target">Transform that supplies target values</param>
        /// <param name="duration">Duration of tween</param>
        /// <param name="isRotationMethodLerp">If true makes linear interpolation, otherwise makes spherical interpolation</param>
        /// <returns>A sequence includes both tweens start at the same time</returns>
        public static Sequence DOMoveAndRotate(this Transform transform, Transform target, float duration,
                                               bool isRotationMethodLerp = true)
        {
            Sequence sequence = DOTween.Sequence();

            sequence.Append(transform.DOMove(target.position, duration));
            sequence.Insert(0,
                isRotationMethodLerp
                    ? transform.DORotateQuaternionLerp(target.rotation, duration)
                    : transform.DORotateQuaternionSlerp(target.rotation, duration));

            return sequence;
        }
        /// <summary>
        /// Makes DOMove and DORotate at the same time
        /// </summary>
        /// <param name="transform">Transform that tween will be played on</param>
        /// <param name="position">Target position</param>
        /// <param name="rotation">Target rotation</param>
        /// <param name="duration">Duration of tween</param>
        /// <param name="isRotationMethodLerp">If true makes linear interpolation, otherwise makes spherical interpolation</param>
        /// <returns>A sequence includes both tweens start at the same time</returns>
        public static Sequence DOMoveAndRotate(this Transform transform, Vector3 position, Quaternion rotation, float duration,
                                               bool isRotationMethodLerp = true)
        {
            Sequence sequence = DOTween.Sequence();

            sequence.Append(transform.DOMove(position, duration));
            sequence.Insert(0,
                isRotationMethodLerp
                    ? transform.DORotateQuaternionLerp(rotation, duration)
                    : transform.DORotateQuaternionSlerp(rotation, duration));

            return sequence;
        }
        public static IEnumerator AsEnumerator(this Tween tween)
        {
            yield return tween.WaitForCompletion();
        }

        public static Coroutine AsCoroutine(this Tween tween)
        {
            return AsEnumerator(tween).StartCoroutine();
        }
    }
}