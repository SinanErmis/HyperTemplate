using System;
using UnityEngine;

namespace Rhodos.Core
{
    /// <summary>
    /// This class for can be used for send analytics events to the server. Thanks to the event driven design, it is easy to
    /// extend and implement different SDK's 
    /// </summary>
    public class AnalyticsManager : MonoBehaviour
    {
        private static float _lastInterstitialTime;
        public static AnalyticsManager instance;

        private int _lastPlayedLevelOrder = -1;

        private void Awake()
        {
            EventManager.OnReloadScene += ShowInterstitial;

            EventManager.OnGameStart += (level, order) =>
            {
                SendEvent($"Level_start_{order}");
                _lastPlayedLevelOrder = order;
            };

            EventManager.OnSuccess += (level, order) => SendEvent($"Level_succeed_{order}");
            EventManager.OnUnsuccess += (level, order) => SendEvent($"Level_failed_{order}");


            if (instance == null)
                Init();
            else if (instance != this)
                Destroy(gameObject);
        }

        private void OnApplicationQuit()
        {
            if (!IsPlayedOnce())
            {
                SendEvent($"First_Session_Level_{_lastPlayedLevelOrder}");
                SendEvent($"First_Session_Interstitial_Count_{GetLifetimeInterstitial()}");
                SavePlayedOnce();
            }
        }

        private static bool IsPlayedOnce() => PlayerPrefs.GetInt("playedonce", 0) == 1;
        private static void SavePlayedOnce() => PlayerPrefs.SetInt("playedonce", 1);
        private void Init()
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private static void ShowInterstitial()
        {
            if (Time.realtimeSinceStartup - _lastInterstitialTime >= 30f)
            {
                SendEvent("Fake_interstitial");
                IncreaseLifetimeInterstitial();
                SendEvent($"Lifetime_Interstitial_{GetLifetimeInterstitial()}");
                _lastInterstitialTime = Time.realtimeSinceStartup;
            }
        }

        private static void IncreaseLifetimeInterstitial() =>
            PlayerPrefs.SetInt("LifetimeInterstital", GetLifetimeInterstitial() + 1);
        private static int GetLifetimeInterstitial() => PlayerPrefs.GetInt("LifetimeInterstitial", 0);


        private static void SendEvent(string eventMessage) => Debug.Log($"<color=blue>EVENT: {eventMessage} </color>");
    }
}