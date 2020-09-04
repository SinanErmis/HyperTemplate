using UnityEngine;
using UnityEngine.SceneManagement;

namespace Rhodos.Core
{
    public class LevelManager : MainComponent
    {
        [SerializeField] private Level[] allLevels;
        [SerializeField] private Level testLevel;
        [SerializeField] private Transform levelHolder;

        public static Level ActiveLevel { get; private set; }

        public override void LateAwake()
        {
            ActiveLevel = CreateLevel();
        }

        /// <summary>
        /// Creates test level if exists, otherwise creates next level.
        /// </summary>
        /// <returns></returns>
        private Level CreateLevel()
        {
            Level level = Instantiate(testLevel != null ? testLevel : allLevels[SaveLoadManager.GetLevel()],
                levelHolder);
            return level;
        }

        public override void SubscribeEvents()
        {
            EventManager.OnReloadScene += ReloadScene;
        }

        public override void UnsubscribeEvents()
        {
            EventManager.OnReloadScene -= ReloadScene;
        }

        private void ReloadScene() => SceneManager.LoadScene("Game");
    }

}