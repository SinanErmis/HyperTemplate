using Rhodos.Toolkit;
using UnityEngine;

namespace Rhodos.Core.Mechanics.Bases
{
    /// <summary>
    /// A base mechanic class that triggers SwipeAction with a direction if swipe length is bigger than minimum length. If not, it triggers OnTap. 
    /// </summary>
    public abstract class SwipeMechanicBase : MechanicBase
    {
        private Vector2 _firstPos;
        protected abstract int MinimumTouchLength { get; set; }

        public override void OnDown()
        {
            _firstPos = Input.mousePosition;
        }

        public override void OnDrag()
        {
            //Empty because with this way child classes won't be forced to implement it. 
        }

        public override void OnUp()
        {
            Vector2 swipe = (Vector2) Input.mousePosition - _firstPos;
            if (swipe.magnitude > MinimumTouchLength)
            {
                //That means if move is in vertical axis
                if (Mathf.Abs(swipe.y) > Mathf.Abs(swipe.x))
                {
                    SwipeAction(swipe.y > 0f ? Direction.Up : Direction.Down);
                }
                else //if move is in horizontal axis
                {
                    SwipeAction(swipe.x > 0f ? Direction.Right : Direction.Left);
                }
            }
            else
            {
                OnTap();
            }
        }

        public abstract void SwipeAction(Direction direction);
        public virtual void OnTap(){}
    }
}