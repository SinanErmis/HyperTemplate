using System;

namespace Rhodos.Core
{
    public class EventManager
    {
        public static event Action OnDown;
        public static event Action OnDrag;
        public static event Action OnUp;

        public static event Action<Level, int> OnGameStart;
        public static event Action<Level, int> OnUnsuccess;
        public static event Action<Level, int> OnSuccess;
        public static event Action OnReloadScene;

        public static event Action<TouchActionTypes> OnTouchActionChanged;

        public static void TriggerOnDown() => OnDown?.Invoke();
        public static void TriggerOnDrag() => OnDrag?.Invoke();
        public static void TriggerOnUp() => OnUp?.Invoke();


        public static void TriggerOnGameStart(Level level, int levelOrder) => OnGameStart?.Invoke(level, levelOrder);
        public static void TriggerOnUnsuccess(Level level, int levelOrder) => OnUnsuccess?.Invoke(level, levelOrder);
        public static void TriggerOnSuccess(Level level, int levelOrder) => OnSuccess?.Invoke(level, levelOrder);
        public static void TriggerOnReloadScene() => OnReloadScene?.Invoke();
        public static void OnOnTouchActionChanged(TouchActionTypes touchActionType) =>
            OnTouchActionChanged?.Invoke(touchActionType);

    }

}