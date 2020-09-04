using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rhodos.Core
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private MainComponent[] mainComponents;

        private void Awake()
        {
            EventManager.OnReloadScene += UnsubscribeAllEvents;
            
            foreach (var mainComponent in mainComponents)
                mainComponent.SubscribeEvents();

            foreach (var mainComponent in mainComponents)
                mainComponent.PreAwake();

            foreach (var mainComponent in mainComponents)
                mainComponent.OnAwake();

            foreach (var mainComponent in mainComponents)
                mainComponent.LateAwake();
        }

        private void UnsubscribeAllEvents()
        {
            foreach (var mainComponent in mainComponents)
                mainComponent.UnsubscribeEvents();
            EventManager.OnReloadScene -= UnsubscribeAllEvents;
        }
    }

}