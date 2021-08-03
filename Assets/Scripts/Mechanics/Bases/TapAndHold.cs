using System;
using UnityEngine;

namespace Rhodos.Mechanics.Bases
{
    public abstract class TapAndHold : Mechanic
    {
        private float _timer;
        [SerializeField] protected float triggerInterval;
        protected abstract void Action();

        public override void OnDrag()
        {
            _timer += Time.deltaTime;
            if (_timer >= triggerInterval)
            {
                Action();
                _timer = 0;
            }
        }

        public override void OnUp()
        {
            _timer = 0f;
        }
    }

}