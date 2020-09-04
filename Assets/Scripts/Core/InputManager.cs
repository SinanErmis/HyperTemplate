using UnityEngine;

namespace Rhodos.Core
{
    public class InputManager : MainComponent
    {
        private bool _canTouch;
        public override void SubscribeEvents()
        {
            EventManager.OnGameStart += DisallowTouch;
            EventManager.OnSuccess += DisallowTouch;
            EventManager.OnUnsuccess += DisallowTouch;
        }
        public override void UnsubscribeEvents()
        {
            EventManager.OnGameStart -= AllowTouch;
            EventManager.OnSuccess -= DisallowTouch;
            EventManager.OnUnsuccess -= DisallowTouch;
        }

        private void AllowTouch(Level level, int order) => _canTouch = true;
        private void DisallowTouch(Level level, int order) => _canTouch = false;
        private void Update()
        {
            if(!_canTouch) return;
            
            if (Input.GetMouseButtonDown(0))
                EventManager.TriggerOnDown();
            
            else if (Input.GetMouseButton(0))
                EventManager.TriggerOnDrag();
            
            else if (Input.GetMouseButtonUp(0))
                EventManager.TriggerOnUp();
        }
    }
}