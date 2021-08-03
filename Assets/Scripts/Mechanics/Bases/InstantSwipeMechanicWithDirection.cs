using Rhodos.Toolkit;
using UnityEngine;

namespace Rhodos.Mechanics.Bases
{
    /// <summary>
    /// A base mechanic class that triggers SwipeAction with a direction and magnitude in every frame that drag continues.
    /// </summary>
    public abstract class InstantSwipeMechanicWithDirection : Mechanic
    {
        private Vector2 _firstPos;

        public override void OnDown()
        {
            _firstPos = Input.mousePosition;
        }

        public override void OnDrag()
        {
            Vector2 swipe = (Vector2) Input.mousePosition - _firstPos;

            //That means if move is in vertical axis
            if (Mathf.Abs(swipe.y) > Mathf.Abs(swipe.x))
            {
                SwipeAction((swipe.y > 0f ? Direction.Up : Direction.Down), swipe.magnitude);
            }
            else //if move is in horizontal axis
            {
                SwipeAction(swipe.x > 0f ? Direction.Right : Direction.Left, swipe.magnitude);
            }
        }

        protected abstract void SwipeAction(Direction direction, float magnitude);
    }
}