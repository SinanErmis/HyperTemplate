using Rhodos.Mechanics.Bases;
using UnityEngine.Events;
using Rhodos.Toolkit;

namespace Rhodos.Core
{
    /// <summary>
    /// Global event manager. This class inherits from mono behaviour because editor events are cool af.
    /// </summary>
    public class EventManager : MonoBehaviourSingleton<EventManager>
    {
        public UnityEvent<LevelArgs>    sceneCreation;  //When scene is created with a particular level
        public UnityEvent<LevelArgs>    gameStart;      //When game started with a particular level 
        public UnityEvent<LevelArgs>    levelSuccess;   //When all mechanics in the level ends
        
        public UnityEvent<MechanicBase> mechanicStart;  //When a mechanic starts
        public UnityEvent<MechanicBase> mechanicFail;   //When player fails
        public UnityEvent<MechanicBase> mechanicSuccess;//When player succeeds
           
        public UnityEvent reloadScene;
        
        public void OnSceneIsCreated(LevelArgs levelArgs) => sceneCreation?.Invoke(levelArgs);
        public void OnGameStart(LevelArgs levelArgs) => gameStart?.Invoke(levelArgs);
        public void OnLevelSuccess(LevelArgs levelArgs) => levelSuccess?.Invoke(levelArgs);
        
        public void OnMechanicStart(MechanicBase mechanicBase) => mechanicStart?.Invoke(mechanicBase);
        public void OnMechanicFail(MechanicBase mechanicBase) => mechanicFail?.Invoke(mechanicBase);
        public void OnMechanicSuccess(MechanicBase mechanicBase) => mechanicSuccess?.Invoke(mechanicBase);
        
        public void OnReloadScene() => reloadScene?.Invoke();
    }

    public class LevelArgs
    {
        public Level Level { get; }
        public int LevelNumber { get; }

        public LevelArgs(Level level, int number)
        {
            Level = level;
            LevelNumber = number;
        }
    }
}