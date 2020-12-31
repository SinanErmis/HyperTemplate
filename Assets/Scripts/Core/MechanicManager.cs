using UnityEngine;
using Rhodos.Core.Mechanics;

namespace Rhodos.Core
{
    public class MechanicManager : MonoBehaviour
    {
        [SerializeField] private InputManager inputManager;
        private static MechanicBase _activeMechanic;
        
        private void ChangeEvents(MechanicBase mechanic)
        {
            if (_activeMechanic != null) UnsubscribeTouchEvents(_activeMechanic);
            SubscribeTouchEvents(mechanic);
            _activeMechanic = mechanic;
        }

        private void SubscribeTouchEvents(MechanicBase mechanic)
        {
            inputManager.OnDown += mechanic.OnDown;
            inputManager.OnDrag += mechanic.OnDrag;
            inputManager.OnUp += mechanic.OnUp;
        }

        private void UnsubscribeTouchEvents(MechanicBase mechanic)
        {
            inputManager.OnDown -= mechanic.OnDown;
            inputManager.OnDrag -= mechanic.OnDrag;
            inputManager.OnUp -= mechanic.OnUp;
        }
    }
}