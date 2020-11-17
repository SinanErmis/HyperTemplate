using System;
using System.Collections;
using UnityEngine;

namespace DORoutine
{
    public static class CoroutineExtensions
    {
        public static Coroutine StartCoroutine(this IEnumerator coroutine)
        {
            return CoroutineCore.CoroutineHandler.StartCoroutine(coroutine);
        }

        public static Coroutine SetDelay(this Coroutine coroutine, float duration, bool isRealtime = true)
        {
            IEnumerator Enumerator()
            {
                if (isRealtime)
                    yield return new WaitForSecondsRealtime(duration);
                else
                    yield return new WaitForSeconds(duration);
                yield return coroutine;
            }

            return Enumerator().StartCoroutine();
        }
        public static Coroutine StartNext(this Coroutine coroutine, IEnumerator enumerator)
        {
            IEnumerator Enumerator()
            {
                yield return coroutine;
                yield return enumerator.StartCoroutine();
            }

            return Enumerator().StartCoroutine();
        }
        public static Coroutine StartNext(this Coroutine coroutine, Coroutine enumerator)
        {
            IEnumerator Enumerator()
            {
                yield return coroutine;
                yield return enumerator;
            }

            return Enumerator().StartCoroutine();
        }

        public static Coroutine OnStart(this Coroutine coroutine, Action onStart)
        {
            IEnumerator OnStart()
            {
                onStart.Invoke();
                yield return coroutine;
            }
            return OnStart().StartCoroutine();
        }
        
        public static Coroutine OnComplete(this Coroutine coroutine, Action onComplete)
        {
            IEnumerator OnComplete()
            {
                onComplete.Invoke();
                yield return coroutine;
            }
            return OnComplete().StartCoroutine();
        }

        public static Coroutine SetLoops(this Coroutine coroutine, int loops)
        {
            IEnumerator LoopingCoroutine()
            {
                for (int i = 0; i < loops; i++)
                {
                    yield return coroutine;
                }
            }
            return LoopingCoroutine().StartCoroutine();
        }

    }
}