using UnityEngine;

namespace Rhodos.Core
{ 
    public class CameraManager : MainComponent
    {
        public static Camera Camera { get; private set; }

        public override void PreAwake()
        {
            Camera = Camera.main;
        }

        /// <summary>
        /// Returns a ray that is on touch point.
        /// </summary>
        /// <returns></returns>
        public static Ray GetTouchRay()
        {
            
            Vector3 nearPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.nearClipPlane);
            Vector3 farPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.farClipPlane);

            Vector3 mousePosFar = Camera.ScreenToWorldPoint(farPos);
            Vector3 mousePosNear = Camera.ScreenToWorldPoint(nearPos);
            Ray ray = new Ray(mousePosNear, mousePosFar - mousePosNear);
            return ray;
        }
    }
}