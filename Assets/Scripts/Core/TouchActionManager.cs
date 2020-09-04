namespace Rhodos.Core
{
    public class TouchActionManager : MainComponent
    {
        private static TouchAction _activeTouchAction;
        
        private void ChangeEvents(TouchAction touchAction)
        {
            if (_activeTouchAction != null) UnsubscribeTouchEvents(_activeTouchAction);
            SubscribeTouchEvents(touchAction);
            _activeTouchAction = touchAction;
        }

        private void SubscribeTouchEvents(TouchAction touchAction)
        {
            EventManager.OnDown += touchAction.OnDown;
            EventManager.OnDrag += touchAction.OnDrag;
            EventManager.OnUp += touchAction.OnUp;

        }
        private void UnsubscribeTouchEvents(TouchAction touchAction)
        {
            EventManager.OnDown -= touchAction.OnDown;
            EventManager.OnDrag -= touchAction.OnDrag;
            EventManager.OnUp -= touchAction.OnUp;
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
        
    }
}