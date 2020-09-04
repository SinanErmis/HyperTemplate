using UnityEngine;

namespace Rhodos.Core
{
    public class SaveLoadManager : MainComponent
    {
        public override void SubscribeEvents() => EventManager.OnSuccess += IncreaseLevel;
        public override void UnsubscribeEvents() => EventManager.OnSuccess -= IncreaseLevel;

        public static void IncreaseLevel(Level level, int order) => PlayerPrefs.SetInt("Level", GetLevel() + 1);
        public static int GetLevel() => PlayerPrefs.GetInt("Level", 0);

        public static float GetChestProgress() => PlayerPrefs.GetFloat("ChestProgress", 0f);
        public static void IncreaseChestProgress(float amount) =>
            PlayerPrefs.SetFloat("ChestProgress", GetChestProgress() + amount);
        public static void SetChestProgress(float amount) => PlayerPrefs.SetFloat("ChestProgress", amount);
    }
}