using System;
using UnityEngine;

namespace Rhodos.Core.Mechanics.Bases
{
    public abstract class TapAndHold : MechanicBase
    {
        private float _timer;
        protected abstract float TriggerInterval { get; set; }
        protected abstract void Action();

        public override void OnDown()
        {
            
        }

        public override void OnDrag()
        {
            _timer += Time.deltaTime;
            if (_timer >= TriggerInterval)
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