using UnityEngine;

namespace Rhodos.Core
{
    public class MechanicManager : MainComponent
    {
        [SerializeField] private InputManager inputManager;
        
        private static Mechanic _activeMechanic;

        public override void SubscribeEvents()
        {
            CentralEventManager.OnMechanicChange += ChangeEvents;
        }

        public override void UnsubscribeEvents()
        {
            CentralEventManager.OnMechanicChange -= ChangeEvents;
        }


        private void ChangeEvents(Mechanic mechanic)
        {
            if (_activeMechanic != null) UnsubscribeTouchEvents(_activeMechanic);
            SubscribeTouchEvents(mechanic);
            _activeMechanic = mechanic;
        }

        private void SubscribeTouchEvents(Mechanic mechanic)
        {
            inputManager.OnDown += mechanic.OnDown;
            inputManager.OnDrag += mechanic.OnDrag;
            inputManager.OnUp += mechanic.OnUp;
        }

        private void UnsubscribeTouchEvents(Mechanic mechanic)
        {
            inputManager.OnDown -= mechanic.OnDown;
            inputManager.OnDrag -= mechanic.OnDrag;
            inputManager.OnUp -= mechanic.OnUp;
        }
    }
}