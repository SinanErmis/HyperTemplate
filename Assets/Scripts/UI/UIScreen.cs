using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;
using MyBox;
using UnityEngine.UI;
using Rhodos.Core;

namespace Rhodos.UI
{
    [RequireComponent(typeof(Canvas), typeof(CanvasScaler))]
    public abstract class UIScreen : MonoBehaviour
    {
        private void Awake()
        {
            AdjustCanvasRatio();
        }

        /// <summary>
        /// Makes UI Screens work properly with every screen size
        /// </summary>
        private void AdjustCanvasRatio()
        {
            float screenRatio;

            float rat = (float) Screen.width / (float) Screen.height;

            if (rat < .56f)
            {
                screenRatio = 0f;
                CameraManager.Camera.fieldOfView += 8;
            }

            else if (rat >= .56f && rat < .624f)
                screenRatio = .5f;
            else
                screenRatio = 1f;
            
            CanvasScaler cs = gameObject.GetComponent<CanvasScaler>();
            if (cs != null) cs.matchWidthOrHeight = screenRatio;
        }

        public abstract IEnumerator PlayInAnimation();

        public abstract IEnumerator PlayOutAnimation();

        [ButtonMethod]
        public void ActivateThisScreen() => UIManager.Instance.ChangeUI(this).StartCoroutine();
    }
}