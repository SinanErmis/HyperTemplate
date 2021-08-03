using UnityEngine;

namespace Rhodos.Mechanics.Bases
{
    /// <summary>
    /// A base mechanic class that triggers SwipeAction with a vector2 in every frame that drag continues.
    /// </summary>
    public abstract class InstantVectorSwipeMechanic : Mechanic
    {
        private Vector2 _firstPos;
        public override void OnDown()
        {
            _firstPos = Input.mousePosition;
        }
        public override void OnDrag()
        {
            SwipeAction((Vector2) Input.mousePosition - _firstPos);
        }
        
        protected abstract void SwipeAction(Vector2 swipe);
    }
}