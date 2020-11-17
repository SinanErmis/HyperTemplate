using System;
using System.Collections;
using UnityEngine;

namespace DORoutine
{
    public class Sequence
    {
        private Coroutine _coroutine = default;
        private IEnumerator Delayer(float duration)
        {
            yield return new WaitForSecondsRealtime(duration);
        }
        
        #region Append Methods

        public Sequence Append(IEnumerator enumerator)
        {
            _coroutine = _coroutine.StartNext(enumerator);
            return this;
        }

        public Sequence Append(Coroutine enumerator)
        {
            _coroutine = _coroutine.StartNext(enumerator);
            return this;
        }

        public Sequence AppendCallback(Action callback)
        {
            _coroutine = _coroutine.OnComplete(callback);
            return this;
        }

        public Sequence AppendInterval(float duration)
        {
            _coroutine = _coroutine.StartNext(Delayer(duration));
            return this;
        }

        #endregion

        #region Prepend Methods


        public Sequence Prepend(IEnumerator enumerator)
        {
            _coroutine = enumerator.StartCoroutine().StartNext(_coroutine);
            return this;
        }

        public Sequence Prepend(Coroutine enumerator)
        {
            _coroutine = enumerator.StartNext(_coroutine);
            return this;
        }

        public Sequence PrependCallback(Action callback)
        {
            _coroutine = _coroutine.OnStart(callback);
            return this;
        }
        
        public Sequence PrependInterval(float duration)
        {
            _coroutine = Delayer(duration).StartCoroutine().StartNext(_coroutine);
            return this;
        }

        #endregion

        public static implicit operator Coroutine(Sequence sequence)
        {
            return sequence._coroutine;
        }
    }
}