using UnityEngine;

namespace Rhodos.Core
{
    public class MechanicManager : MainComponent
    {
        [SerializeField] private InputManager inputManager;
        
        private static Mechanic _activeMechanic;
        private static Mechanic[] _mechanics;

        public override void SubscribeEvents()
        {
            CentralEventManager.OnTouchActionChanged += ChangeEventsWithEnum;
        }

        public override void UnsubscribeEvents()
        {
            CentralEventManager.OnTouchActionChanged -= ChangeEventsWithEnum;
        }

        public override void PreAwake()
        {
            _mechanics = new Mechanic[0]
            {
                //TODO add foreach touch action to here (2)
                //for example:
                //ArrowThrowing arrowThrowing = new ArrowThrowing();
                //GunShooting gunShooting = new GunShooting();
                //ArrowThrowing should be in first place at action type enum
            };
        }

        private void ChangeEventsWithEnum(MechanicType mechanicType)
        {
            ChangeEvents(_mechanics[(int) mechanicType]);
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

    public abstract class Mechanic
    {
        public abstract void OnDown();
        public abstract void OnDrag();
        public abstract void OnUp();
    }

    /// <summary>
    /// Stores touch action types for making easier both level creating and activating different touch actions.
    /// </summary>
    public enum MechanicType
    {
        //TODO add touch actions here (1)
    }
}