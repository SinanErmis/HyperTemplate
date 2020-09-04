using UnityEngine;

namespace Rhodos.Core
{
    public abstract class MainComponent : MonoBehaviour
    {
        public virtual void SubscribeEvents()
        {
        }
        public virtual void UnsubscribeEvents()
        {
        }

        public virtual void PreAwake()
        {
        }

        public virtual void OnAwake()
        {
        }

        public virtual void LateAwake()
        {
        }
    }
}