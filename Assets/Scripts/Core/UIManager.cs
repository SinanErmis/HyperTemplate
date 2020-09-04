using System;
using DG.Tweening;
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

        public static void ChangeUI(UIScreen uiScreen)
        {
            if (_activeScreen == null)
            {
                Debug.Log("<color=green>Giren UI: </color>" + uiScreen.name);
                uiScreen.PlayInAnimation();
            }
            else
            {
                Debug.Log("<color=red>Çıkan UI: </color>" + _activeScreen + "\n<color=green>Giren UI: </color>" +
                          uiScreen);
                _activeScreen.PlayOutAnimation().OnComplete(() => uiScreen.PlayInAnimation());
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