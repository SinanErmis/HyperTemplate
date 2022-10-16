using System;
using System.Collections;
using NaughtyAttributes;
using Rhodos.Mechanics.Bases;
using Toolkit;
using UnityEngine;

namespace Rhodos.Core
{
    /// <summary>
    /// General game manager. Handles game flow and also serves as service locator. 
    /// </summary>
    public class GameManager : SingletonBehaviour<GameManager>
    {
        public bool canPlay;
        public GameType gameType;

        /// <summary>
        /// Handles mechanic change and/or level success status.
        /// </summary>
        public Coroutine OnSuccess()
        {
            return StartCoroutine(InnerOnSuccess());
            
            IEnumerator InnerOnSuccess()
            {
                yield return StartCoroutine(MechanicManager.Instance.ActiveMechanic.OnEnd());

                if (MechanicManager.Instance.DidLevelEnd)
                {
                    SaveLoadManager.Instance.IncreaseLevel();
                    StartCoroutine(UIManager.Instance.ChangeUI(UIManager.MainScreens.Success));
                    AnalyticsManager.ShowInterstitial();
                }
                else
                {
                    MechanicManager.Instance.IncreaseMechanicCounter();
                    yield return StartCoroutine(MechanicManager.Instance.ActiveMechanic.OnStart());
                }
            }
        }

        public Coroutine OnFail()
        {
            return StartCoroutine(InnerOnFail());

            IEnumerator InnerOnFail()
            {
                yield return StartCoroutine(MechanicManager.Instance.ActiveMechanic.OnFail());
                StartCoroutine(UIManager.Instance.ChangeUI(UIManager.MainScreens.Fail));
            }
        }

        public enum GameType
        {
            UniqueLevels,
            UniqueMechanics
        }
    }
}
