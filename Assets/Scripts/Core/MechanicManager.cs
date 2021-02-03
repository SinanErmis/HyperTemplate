using System;
using Rhodos.Core.Mechanics.Bases;
using UnityEngine;

namespace Rhodos.Core
{
    public class MechanicManager : MonoBehaviour
    {
        public MechanicBase activeMechanic;
        
        #region Events
        private event Action OnDown;
        private event Action OnDrag;
        private event Action OnUp;
        public object IsActiveMechanicExist => activeMechanic != null;

        public void TriggerOnDown() => OnDown?.Invoke();
        public void TriggerOnDrag() => OnDrag?.Invoke();
        public void TriggerOnUp() => OnUp?.Invoke();
        #endregion
        
        //subs to on mechanic change
        public void ChangeEvents(MechanicBase mechanic)
        {
            if (activeMechanic != null)
            {
                UnsubscribeTouchEvents(activeMechanic);
                activeMechanic.OnDisactivate();
            }
            activeMechanic = mechanic;
            SubscribeTouchEvents(activeMechanic);
            activeMechanic.OnActivate();
            
        }

        private void SubscribeTouchEvents(MechanicBase mechanic)
        {
            OnDown += mechanic.OnDown;
            OnDrag += mechanic.OnDrag;
            OnUp += mechanic.OnUp;
        }

        private void UnsubscribeTouchEvents(MechanicBase mechanic)
        {
            OnDown -= mechanic.OnDown;
            OnDrag -= mechanic.OnDrag;
            OnUp -= mechanic.OnUp;
        }
    }
}