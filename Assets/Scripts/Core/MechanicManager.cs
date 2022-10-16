using System;
using MyBox;
using NaughtyAttributes;
using Rhodos.Mechanics.Bases;
using Toolkit;
using UnityEngine;

namespace Rhodos.Core
{
    public class MechanicManager : SingletonBehaviour<MechanicManager>
    {
        [HideInInspector] public bool isGameTypeUniqueMechanics;
        [EnableIf("isGameTypeUniqueMechanics")] public Mechanic[] mechanics;
        
        public Mechanic ActiveMechanic => mechanics[_index];
        private int _index;
        
        public bool DidLevelEnd => _index + 1 >= mechanics.Length;
        public void IncreaseMechanicCounter() => _index++;

        private void Update()
        {
            if(!GameManager.Instance.canPlay) return;

            if (Input.GetMouseButtonDown(0))
                ActiveMechanic.OnDown();
            else if (Input.GetMouseButton(0))
                ActiveMechanic.OnDrag();
            else if (Input.GetMouseButtonUp(0))
                ActiveMechanic.OnUp();
        }

    }
}