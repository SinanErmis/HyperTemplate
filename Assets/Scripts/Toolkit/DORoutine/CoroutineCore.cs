using UnityEngine;

namespace DORoutine
{
    public static class CoroutineCore
    {
        public static CoroutineHandler CoroutineHandler { get; }

        static CoroutineCore()
        {
            GameObject go = new GameObject("Coroutine Handler");
            CoroutineHandler = go.AddComponent<CoroutineHandler>();
            go.hideFlags = HideFlags.HideInHierarchy;
        }

    }


}