using UnityEngine;

namespace Toolkit
{
    public class SingletonBehaviour<T> : MonoBehaviour where T : SingletonBehaviour<T>
    {
        private static T _instance;
        public static T Instance
        {
            get
            {
                if (_instance) return _instance;
                
                var objects = FindObjectsOfType<T>();
                
                if (objects.Length == 0)
                {
                    var go = new GameObject($"[{typeof(T).Name}]");
                    DontDestroyOnLoad(go);
                    var instance = go.AddComponent<T>();
                    return _instance = instance;
                }
                
                if (objects.Length > 1)
                {
                    Debug.LogWarning($"There are more than one instance of {typeof(T)} in the scene! Using first one as Instance and ignoring others.\nYou can think about dealing the other instances.");
                }
                
                _instance = objects[0];
                return _instance;
            }
        }
    }
}