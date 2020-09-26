namespace Rhodos.Core
{
    public class TouchActionManager : MainComponent
    {
        private static TouchAction _activeTouchAction;
        private static TouchAction[] _touchActions;

        public override void SubscribeEvents()
        {
            CentralEventManager.OnTouchActionChanged += ChangeEventsWithEnum;
        }

        public override void UnsubscribeEvents()
        {
            CentralEventManager.OnTouchActionChanged -= ChangeEventsWithEnum;
        }

        public override void PreAwake()
        {
            _touchActions = new TouchAction[0]
            {
                //TODO add foreach touch action to here (2)
                //for example:
                //ArrowThrowing arrowThrowing = new ArrowThrowing();
                //GunShooting gunShooting = new GunShooting();
                //ArrowThrowing should be in first place at action type enum
            };
        }

        private void ChangeEventsWithEnum(TouchActionTypes touchActionType)
        {
            ChangeEvents(_touchActions[(int) touchActionType]);
        }

        private void ChangeEvents(TouchAction touchAction)
        {
            if (_activeTouchAction != null) UnsubscribeTouchEvents(_activeTouchAction);
            SubscribeTouchEvents(touchAction);
            _activeTouchAction = touchAction;
        }

        private void SubscribeTouchEvents(TouchAction touchAction)
        {
            CentralEventManager.OnDown += touchAction.OnDown;
            CentralEventManager.OnDrag += touchAction.OnDrag;
            CentralEventManager.OnUp += touchAction.OnUp;
        }

        private void UnsubscribeTouchEvents(TouchAction touchAction)
        {
            CentralEventManager.OnDown -= touchAction.OnDown;
            CentralEventManager.OnDrag -= touchAction.OnDrag;
            CentralEventManager.OnUp -= touchAction.OnUp;
        }
    }

    public abstract class TouchAction
    {
        public abstract void OnDown();
        public abstract void OnDrag();
        public abstract void OnUp();
    }

    /// <summary>
    /// Stores touch action types for making easier both level creating and activating different touch actions.
    /// </summary>
    public enum TouchActionTypes
    {
        //TODO add touch actions here (1)
    }
}