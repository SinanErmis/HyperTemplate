using UnityEngine;

namespace Rhodos.Core
{
    public abstract class Mechanic : MonoBehaviour
    {
        [SerializeField] private MechanicType mechanicType;
        public static implicit operator MechanicType(Mechanic mechanic) => mechanic.mechanicType;
        public abstract void OnDown();
        public abstract void OnDrag();
        public abstract void OnUp();
    }

}