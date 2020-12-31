using UnityEngine;

namespace Rhodos.Core.Mechanics
{
    /// <summary>
    /// A base mechanic class that triggers SwipeAction with a vector2 in every frame that drag continues.
    /// </summary>
    public abstract class VectorSwipeMechanicBase : MechanicBase
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

        public override void OnUp()
        {
            //Empty because with this way child classes won't be forced to implement it.
        }

        protected abstract void SwipeAction(Vector2 swipe);
    }
}