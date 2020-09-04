using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Rhodos.Core;

namespace Rhodos.UI
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

        [ContextMenu("Activate this")]
        public void Activate() => UIManager.ChangeUI(this);

    }
}