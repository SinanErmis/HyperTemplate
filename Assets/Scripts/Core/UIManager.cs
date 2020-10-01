using System;
using System.Collections;
using DG.Tweening;
using MyBox;
using UnityEngine;
using UnityEngine.UI;
using Rhodos.UI;

namespace Rhodos.Core
{
    public class UIManager : MainComponent
    {
        [SerializeField] private UIScreen[] uiScreens;
        private static UIScreen _activeScreen;

        public override void SubscribeEvents()
        {
            foreach (var uiScreen in uiScreens)
                uiScreen.SubscribeEvents();
        }

        public override void UnsubscribeEvents()
        {
            foreach (var uiScreen in uiScreens)
                uiScreen.UnsubscribeEvents();
        }

        public override void OnAwake()
        {
            AdjustCanvasRatio();
        }

        private void Start()
        {
            foreach (var uiScreen in uiScreens)
                uiScreen.OnStart();
        }

        public static IEnumerator ChangeUI(UIScreen uiScreen)
        {
            if (_activeScreen == null)
            {
                Debug.Log("Screen In".Colored(Colors.green) + uiScreen.name);
                uiScreen.PlayInAnimation();
            }
            else
            {
                Debug.Log("Screen OUT".Colored(Colors.red) + _activeScreen +
                          "\nScreen In".Colored(Colors.green) + uiScreen);
                
                yield return uiScreen.StartCoroutine(_activeScreen.PlayOutAnimation())
                                     .StartNext(uiScreen.PlayInAnimation());
            }
            _activeScreen = uiScreen;
        }

        /// <summary>
        /// Makes UI Screens work properly on both Iphones and Ipads
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


            foreach (UIScreen uiScreen in uiScreens)
            {
                CanvasScaler cs = uiScreen.gameObject.GetComponent<CanvasScaler>();
                if (cs != null) cs.matchWidthOrHeight = screenRatio;
            }
        }
    }
}