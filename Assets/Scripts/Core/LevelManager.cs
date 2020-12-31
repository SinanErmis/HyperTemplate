using UnityEngine;
using UnityEngine.SceneManagement;

namespace Rhodos.Core
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private Level[] allLevels;
        [SerializeField] private Level testLevel;
        [SerializeField] private Transform levelHolder;

        public static Level ActiveLevel { get; private set; }

        private void Awake()
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

        private void RestartScene() => SceneManager.LoadScene("Game");
    }

}