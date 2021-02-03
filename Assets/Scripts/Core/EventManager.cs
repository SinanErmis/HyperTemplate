using Rhodos.Core.Mechanics.Bases;
using UnityEngine.Events;
using Rhodos.Toolkit;

namespace Rhodos.Core
{
    /// <summary>
    /// Global event manager. This class inherits from mono behaviour because editor events are cool af.
    /// </summary>
    public class EventManager : MonoBehaviourSingleton<EventManager>
    {
        //todo rename game start scene start and unsuccess fail
        public UnityEvent<LevelArgs> sceneCreated;
        public UnityEvent<LevelArgs> gameStart;
        public UnityEvent<LevelArgs> fail;
        public UnityEvent<LevelArgs> levelSuccess;
        public UnityEvent mechanicSuccess;
        public UnityEvent reloadScene;
        public UnityEvent<MechanicBase> mechanicChange;
           
        public void TriggerOnSceneCreated(LevelArgs levelArgs) => sceneCreated?.Invoke(levelArgs);
        public void TriggerOnGameStart(LevelArgs levelArgs) => gameStart?.Invoke(levelArgs);
        public void TriggerOnFail(LevelArgs levelArgs) => fail?.Invoke(levelArgs);
        public void TriggerOnLevelSuccess(LevelArgs levelArgs) => levelSuccess?.Invoke(levelArgs);
        public void TriggerOnMechanicSuccess() => mechanicSuccess?.Invoke();
        public void TriggerOnReloadScene() => reloadScene?.Invoke();
        public void TriggerOnMechanicChange(MechanicBase mechanic) => mechanicChange?.Invoke(mechanic);

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