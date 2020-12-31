using System;
using UnityEngine;

namespace Rhodos.Toolkit
{
    public class MonoBehaviourSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance { get; private set; } = null;

        public virtual void Awake()
        {
            if (Instance == null) 
            {
                Instance = this as T;
            }
            else
            {
                Debug.LogError("WARNING! There are more than one " + typeof(T) + " in the scene. Extra ones will be terminated.");
                Destroy(gameObject);
            }
            
        }
    }
}