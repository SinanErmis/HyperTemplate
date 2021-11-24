using System;
using System.Collections;
using DG.Tweening;
using MyBox;
using UnityEngine;
using UnityEngine.UI;
using Rhodos.UI;

namespace Rhodos.Core
{
    public class UIManager : MonoBehaviour
    {
        public UIScreen ActiveScreen { get; private set; }

        private IEnumerator Start()
        {
            yield return null;
            StartCoroutine(ChangeUI(MainScreens.MainMenu));
        }

        public IEnumerator ChangeUI(UIScreen uiScreen)
        {
            if (ActiveScreen) yield return StartCoroutine(ActiveScreen.PlayOutAnimation());
            ActiveScreen = uiScreen;
            if (ActiveScreen) yield return StartCoroutine(ActiveScreen.PlayInAnimation());
        }
        public IEnumerator ChangeUI(MainScreens screen)
        {
            UIScreen uiScreen = screen switch
            {
                MainScreens.MainMenu => GameManager.I.Managers.UIManager.mainMenu,
                MainScreens.Success  => GameManager.I.Managers.UIManager.success,
                MainScreens.Fail     => GameManager.I.Managers.UIManager.fail,
                _ => throw new ArgumentOutOfRangeException(nameof(screen), screen, null)
            };

            return ChangeUI(uiScreen);
        }

        // ! future idea
        /*enum GameStartType
        {
            WithPlayButton, //simple one
            SeamlessButton, //again with a button, but this button triggers first OnDown so creates a seamless transition
            WithoutAnything,//start first mechanic when scene loaded
        }*/

        public enum MainScreens
        {
            MainMenu,
            Success,
            Fail
        }

        [SerializeField] private MainMenu mainMenu;
        [SerializeField] private SuccessScreen success;
        [SerializeField] private FailScreen fail;
        
        
    }
}
