using Rhodos.Mechanics.Bases;
using UnityEngine;

namespace Rhodos
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private MechanicBase[] levelMechanics;
        private int _activeMechanicIndex;
        public bool IsEnded => levelMechanics.Length == _activeMechanicIndex;
        public MechanicBase ActiveMechanic => levelMechanics[_activeMechanicIndex];

        public void IncreaseMechanicIndex()
        {
            _activeMechanicIndex++;
        }
    }
}