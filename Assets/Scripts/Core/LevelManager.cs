using Rhodos.Mechanics.Bases;
using Toolkit;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Rhodos.Core
{
    public class LevelManager : SingletonBehaviour<LevelManager>
    {
        [SerializeField] private Level[] allLevels;
        [SerializeField] private Level testLevel;
        [SerializeField] private Transform levelHolder;

        public static Level ActiveLevel { get; private set; }

        private void Start()
        {
            ActiveLevel = CreateLevel();
            MechanicManager.Instance.mechanics = ActiveLevel.LevelMechanics;
        }

        /// <summary>
        /// Creates test level if exists, otherwise creates next level.
        /// </summary>
        /// <returns></returns>
        private Level CreateLevel()
        {
            Level level = Instantiate(testLevel != null ? testLevel : allLevels[SaveLoadManager.GetLevel() % allLevels.Length],
                levelHolder);
            return level;
        }

        public static void RestartScene() => SceneManager.LoadScene("Game");
    }

}
