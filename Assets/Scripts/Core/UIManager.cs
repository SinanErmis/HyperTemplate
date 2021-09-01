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
        private static UIScreen _activeScreen;

        private IEnumerator Start()
        {
            yield return null;
            StartCoroutine(ChangeUI(MainScreens.MainMenu));
        }

        public static IEnumerator ChangeUI(UIScreen uiScreen)
        {
            if (_activeScreen == null)
            {
                Debug.Log("Screen In: ".Colored(Colors.green) + uiScreen.name);
                uiScreen.PlayInAnimation().StartCoroutine();
            }
            else
            {
                Debug.Log("Screen Out: ".Colored(Colors.red) + _activeScreen +
                          "\nScreen In: ".Colored(Colors.green) + uiScreen);
                
                yield return uiScreen.StartCoroutine(_activeScreen.PlayOutAnimation())
                                     .StartNext(uiScreen.PlayInAnimation());
            }
            _activeScreen = uiScreen;
        }
        public static IEnumerator ChangeUI(MainScreens screen)
        {
            UIScreen uiScreen = screen switch
            {
                MainScreens.MainMenu => GameManager.I.Managers.UIManager.mainMenu,
                MainScreens.Success  => GameManager.I.Managers.UIManager.success,
                MainScreens.Fail     => GameManager.I.Managers.UIManager.fail,
                _ => throw new ArgumentOutOfRangeException(nameof(screen), screen, null)
            };
            
            if (_activeScreen == null)
            {
                Debug.Log("Screen In: ".Colored(Colors.green) + uiScreen.name);
                uiScreen.PlayInAnimation().StartCoroutine();
            }
            else
            {
                Debug.Log("Screen Out: ".Colored(Colors.red) + _activeScreen +
                          "\nScreen In: ".Colored(Colors.green) + uiScreen);
                
                yield return uiScreen.StartCoroutine(_activeScreen.PlayOutAnimation())
                    .StartNext(uiScreen.PlayInAnimation());
            }
            _activeScreen = uiScreen;
        }
        
        public static IEnumerator EmptyUI()
        {
            yield return _activeScreen.StartCoroutine(_activeScreen.PlayOutAnimation());
            _activeScreen = null;
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
