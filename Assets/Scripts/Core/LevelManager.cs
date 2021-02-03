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
        
        private void Start()
        {
            ActiveLevel = CreateLevel();
            EventManager.Instance.TriggerOnSceneCreated(new LevelArgs(ActiveLevel, SaveLoadManager.GetLevel()));
            EventManager.Instance.TriggerOnMechanicChange(ActiveLevel.ActiveMechanic);

        }

        //subs to on mechanic success
        public void NextMechanicOrNextLevel()
        {
            ActiveLevel.IncreaseMechanicIndex();

            if (ActiveLevel.IsEnded)
            {
                EventManager.Instance.TriggerOnLevelSuccess(new LevelArgs(ActiveLevel, SaveLoadManager.GetLevel()));
            }
            else
            {
                EventManager.Instance.TriggerOnMechanicChange(ActiveLevel.ActiveMechanic);
            }
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

        public void RestartScene() => SceneManager.LoadScene("Game");
    }

}