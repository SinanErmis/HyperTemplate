using Rhodos.Core.Mechanics.Bases;
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
            LevelArgs currentArgs = new LevelArgs(ActiveLevel, SaveLoadManager.GetLevel());
            EventManager.Instance.OnSceneIsCreated(currentArgs);
            
            //Uncomment it if you want to start game without an onboarding / main menu screen.
            //EventManager.Instance.OnGameStart(currentArgs);
        }

        //subs to on mechanic success
        public void HandleMechanicChange(MechanicBase mechanic)
        {
            ActiveLevel.IncreaseMechanicIndex();

            if (ActiveLevel.IsEnded)
            {
                EventManager.Instance.OnLevelSuccess(new LevelArgs(ActiveLevel, SaveLoadManager.GetLevel()));
            }
            else
            {
                EventManager.Instance.OnMechanicStart(ActiveLevel.ActiveMechanic);
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