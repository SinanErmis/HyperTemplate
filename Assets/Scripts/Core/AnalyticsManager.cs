using System;
using Toolkit;
using UnityEngine;

namespace Rhodos.Core
{
    /// <summary>
    /// This class for can be used for send analytics events to the server.
    /// To use with different SDKs replace body of SendEvent() method.
    /// </summary>
    public class AnalyticsManager : SingletonBehaviour<AnalyticsManager>
    {
        private int _lastPlayedLevelOrder = -1;
        private static float _lastInterstitialTime;
        private const float INTERSTITIAL_INTERVAL = 30f;

        #region Keys

        private const string PLAYED_ONCE_KEY = "PlayedOnce";
        private const string LIFETIME_INTERSTITIAL_KEY = "LifetimeInterstitial";
        
        #endregion

        private bool DidPlayerPlayOnce
        {
            get => PlayerPrefs.GetInt(PLAYED_ONCE_KEY, 0) == 1;
            set => PlayerPrefs.SetInt(PLAYED_ONCE_KEY, 1);
        }

        private void OnApplicationQuit()
        {
            if (!DidPlayerPlayOnce)
            {
                SendEvent($"First_Session_Level_{_lastPlayedLevelOrder}");
                SendEvent($"First_Session_Interstitial_Count_{GetLifetimeInterstitial()}");
                DidPlayerPlayOnce = true;
            }
        }

        public static void ShowInterstitial()
        {
            if (Time.realtimeSinceStartup - _lastInterstitialTime >= INTERSTITIAL_INTERVAL)
            {
                SendEvent("Fake_interstitial");
                IncreaseLifetimeInterstitial();
                SendEvent($"{LIFETIME_INTERSTITIAL_KEY}_{GetLifetimeInterstitial()}");
                _lastInterstitialTime = Time.realtimeSinceStartup;
            }
        }

        private static void IncreaseLifetimeInterstitial() =>
            PlayerPrefs.SetInt(LIFETIME_INTERSTITIAL_KEY, GetLifetimeInterstitial() + 1);
        private static int GetLifetimeInterstitial() => PlayerPrefs.GetInt(LIFETIME_INTERSTITIAL_KEY, 0);


        private static void SendEvent(string eventMessage) => Debug.Log($"<color=blue>EVENT: {eventMessage} </color>");
    }
}