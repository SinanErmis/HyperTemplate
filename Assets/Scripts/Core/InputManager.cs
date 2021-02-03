using System;
using UnityEngine;

namespace Rhodos.Core
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private MechanicManager mechanicManager;

        private static bool _canTouch;

        public void ActivateGetTouchInput()
        {
            _canTouch = true;
        }
        public void DeactivateGetTouchInput()
        {
            _canTouch = false;
        }

        private void Update()
        {
            if(!_canTouch) return;
            //if(mechanicManager.IsActiveMechanicExist == null) return;
            if (!mechanicManager.activeMechanic.canPlay) return;
            
            if (Input.GetMouseButtonDown(0))
                mechanicManager.TriggerOnDown();
            
            else if (Input.GetMouseButton(0))
                mechanicManager.TriggerOnDrag();
            
            else if (Input.GetMouseButtonUp(0))
                mechanicManager.TriggerOnUp();
        }
    }
}