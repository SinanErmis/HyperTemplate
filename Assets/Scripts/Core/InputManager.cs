using System;
using UnityEngine;

namespace Rhodos.Core
{
    public class InputManager : MonoBehaviour
    {
        private bool _canTouch;

        #region Events
        public event Action OnDown;
        public event Action OnDrag;
        public event Action OnUp;
        public void TriggerOnDown() => OnDown?.Invoke();
        public void TriggerOnDrag() => OnDrag?.Invoke();
        public void TriggerOnUp() => OnUp?.Invoke();
        #endregion

        private void Update()
        {
            if(!_canTouch) return;
            
            if (Input.GetMouseButtonDown(0))
                TriggerOnDown();
            
            else if (Input.GetMouseButton(0))
                TriggerOnDrag();
            
            else if (Input.GetMouseButtonUp(0))
                TriggerOnUp();
        }
    }
}