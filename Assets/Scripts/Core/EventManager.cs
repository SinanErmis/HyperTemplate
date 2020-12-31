using UnityEngine.Events;
using Rhodos.Toolkit;
using Rhodos.Core.Mechanics;

namespace Rhodos.Core
{
       /// <summary>
       /// Global event manager. This class inherits from mono behaviour because editor events are cool af.
       /// </summary>
       public class EventManager : MonoBehaviourSingleton<EventManager>
       {
           public UnityEvent<LevelArgs> gameStart;
           public UnityEvent<LevelArgs> unsuccess;
           public UnityEvent<LevelArgs> success;
           public UnityEvent reloadScene;
           public UnityEvent<MechanicBase> mechanicChange;
           
           public void TriggerOnGameStart(LevelArgs levelArgs) => gameStart?.Invoke(levelArgs);
           public void TriggerOnUnsuccess(LevelArgs levelArgs) => unsuccess?.Invoke(levelArgs);
           public void TriggerOnSuccess(LevelArgs levelArgs) => success?.Invoke(levelArgs);
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