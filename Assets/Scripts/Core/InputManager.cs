using UnityEngine;

namespace Rhodos.Core
{
    public class InputManager : MainComponent
    {
        private bool _canTouch;
        public override void SubscribeEvents()
        {
            CentralEventManager.OnGameStart += DisallowTouch;
            CentralEventManager.OnSuccess += DisallowTouch;
            CentralEventManager.OnUnsuccess += DisallowTouch;
        }
        public override void UnsubscribeEvents()
        {
            CentralEventManager.OnGameStart -= AllowTouch;
            CentralEventManager.OnSuccess -= DisallowTouch;
            CentralEventManager.OnUnsuccess -= DisallowTouch;
        }

        private void AllowTouch(Level level, int order) => _canTouch = true;
        private void DisallowTouch(Level level, int order) => _canTouch = false;
        private void Update()
        {
            if(!_canTouch) return;
            
            if (Input.GetMouseButtonDown(0))
                CentralEventManager.TriggerOnDown();
            
            else if (Input.GetMouseButton(0))
                CentralEventManager.TriggerOnDrag();
            
            else if (Input.GetMouseButtonUp(0))
                CentralEventManager.TriggerOnUp();
        }
    }
}