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
    }
}