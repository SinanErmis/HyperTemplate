using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace Rhodos.Core
{
    [RequireComponent(typeof(Canvas), typeof(CanvasScaler))]
    public abstract class UIScreen : MonoBehaviour
    {
        public virtual void SubscribeEvents()
        {
        }

        public virtual void UnsubscribeEvents()
        {
        }

        /// <summary>
        /// Stores to-dos of UI Screens. Executes after all main components' awake methods.
        /// </summary>
        public virtual void OnStart()
        {
        }

        public abstract Sequence PlayInAnimation();
        public abstract Sequence PlayOutAnimation();
        
        public void Activate() => UIManager.ChangeUI(this);

    }
}