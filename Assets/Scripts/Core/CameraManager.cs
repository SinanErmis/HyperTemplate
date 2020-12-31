using UnityEngine;

namespace Rhodos.Core
{ 
    public class CameraManager : MonoBehaviour
    {
        public static Camera Camera { get; private set; }

        public void Awake()
        {
            Camera = Camera.main;
        }
    }
}