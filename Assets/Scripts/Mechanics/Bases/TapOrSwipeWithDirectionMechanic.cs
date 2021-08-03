using Rhodos.Toolkit;
using UnityEngine;

namespace Rhodos.Mechanics.Bases
{
    /// <summary>
    /// A base mechanic class that triggers SwipeAction with a direction if swipe length is bigger than minimum length. If not, it triggers OnTap. 
    /// </summary>
    public abstract class TapOrSwipeWithDirectionMechanic : Mechanic
    {
        private Vector2 _firstPos;
        [SerializeField] protected int minimumTouchLength;

        public override void OnDown()
        {
            _firstPos = Input.mousePosition;
        }

        public override void OnUp()
        {
            Vector2 swipe = (Vector2) Input.mousePosition - _firstPos;
            if (swipe.magnitude > minimumTouchLength)
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

        protected virtual void SwipeAction(Direction direction){}
        protected virtual void OnTap(){}
    }
}