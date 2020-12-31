using System.Collections;
using DG.Tweening;
using UnityEngine;
using MyBox;

namespace Rhodos.Toolkit.Extensions
{
    public static class DOTweenExtensions
    {
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