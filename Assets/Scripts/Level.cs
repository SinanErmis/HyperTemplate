using Rhodos.Mechanics.Bases;
using UnityEngine;

namespace Rhodos
{
    public class Level : MonoBehaviour
    {
        [field : SerializeField] public Mechanic[] LevelMechanics { get; private set; }
    }
}