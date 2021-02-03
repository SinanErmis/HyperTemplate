using System;
using System.Collections;
using MyBox;
using UnityEngine;

namespace Rhodos.Toolkit.Extensions
{
    public static class CoroutineExtensions
    {
        public static Coroutine OnComplete(this Coroutine coroutine, Action onComplete)
        {
            return OnCompleteEnumerator(coroutine, onComplete).StartCoroutine();
        }

        private static IEnumerator OnCompleteEnumerator(Coroutine coroutine, Action action)
        {
            yield return coroutine;
            action();
        }
    }
}