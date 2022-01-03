using UnityEngine;
using System.Collections;
namespace Rhodos.Toolkit.Extensions
{
    public static class TransformExtensions
    {
        /// <summary>
        /// Translates transforms position to target in given time. Works like DOPosition but uses IEnumerator
        /// </summary>
        public static IEnumerator TranslateInTime(this Transform transform, Vector3 target, float duration)
        {
            Vector3 startingPos = transform.position;

            float timer = 0f;
            while (timer < duration) 
            {
                timer += Time.deltaTime;
                transform.position = Vector3.Lerp(startingPos, target, timer / duration);
                yield return null;
            }
        }
                
        public static void SlowLookAt(this Transform transform, Vector3 target, float speed)
        {
            Quaternion targetRot = Quaternion.FromToRotation(transform.position, target);
            transform.rotation = Quaternion.Slerp(transform.rotation , targetRot, Time.deltaTime * speed);
        }
        
        public static void SlowLookAt(this Transform transform, Transform target, float speed)
        {
            Quaternion targetRot = Quaternion.FromToRotation(transform.position, target.position);
            transform.rotation = Quaternion.Slerp(transform.rotation , targetRot, Time.deltaTime * speed);
        }
        
        public static void SlowMoveTo(this Transform transform, Vector3 target, float speed)
        {
            transform.position = Vector3.Lerp(transform.position , target, Time.deltaTime * speed);
        }
        
        public static void SlowMoveTo(this Transform transform, Transform target, float speed)
        {
            transform.position = Vector3.Lerp(transform.position , target.position, Time.deltaTime * speed);
        }
        
        public static void CopyValuesFrom(this Transform original, Transform target)
        {
            original.SetPositionAndRotation(target.position, target.rotation);
        }

        public static IEnumerator CopyValuesFromInTime(this Transform original, Transform target, float duration)
        {
            float timer = 0f;
            
            Vector3 startingPos = original.position, targetPos = target.position;
            Quaternion startingRotation = original.rotation, targetRot = target.rotation;
            
            while (timer < duration)
            {
                yield return null;
                timer += Time.deltaTime;
                float percentage = timer / duration;
                Vector3 pos = Vector3.Lerp(startingPos, targetPos, percentage);
                Quaternion rot = Quaternion.Lerp(startingRotation, targetRot, percentage);
                original.SetPositionAndRotation(pos,rot);
            }
        }
    }
}
