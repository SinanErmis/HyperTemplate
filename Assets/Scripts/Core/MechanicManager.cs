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
        
        public void CallMechanicActivateSequence(MechanicBase mechanicBase)
        {
            mechanicBase.StartCoroutine(mechanicBase.OnActivate());
        }
        public void CallMechanicDeactivate(MechanicBase mechanicBase)
        {
            mechanicBase.OnDeactivate();
        }        
        public void CallMechanicFail(MechanicBase mechanicBase)
        {
            mechanicBase.OnFail();
        }

        public void StartFirstMechanic(LevelArgs level)
        {
            EventManager.Instance.OnMechanicStart(level.Level.ActiveMechanic);
        }

        public void SubscribeTouchEvents(MechanicBase mechanic)
        {
            activeMechanic = mechanic;
            OnDown += mechanic.OnDown;
            OnDrag += mechanic.OnDrag;
            OnUp += mechanic.OnUp;
        }

        public void UnsubscribeTouchEvents(MechanicBase mechanic)
        {
            activeMechanic = null;
            OnDown -= mechanic.OnDown;
            OnDrag -= mechanic.OnDrag;
            OnUp -= mechanic.OnUp;
        }
    }
}