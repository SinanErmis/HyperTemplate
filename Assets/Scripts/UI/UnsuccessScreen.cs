using System.Collections;
using Rhodos.Core;
using DG.Tweening;
using UnityEngine;

namespace Rhodos.UI
{
    public class UnsuccessScreen : UIScreen
    {
        [SerializeField] private Chest chest;
        //TODO chest initilization/opening changes foreach game.
        
        public override void SubscribeEvents() => EventManager.OnUnsuccess += ActivateOnUnsuccess;
        public override void UnsubscribeEvents() => EventManager.OnUnsuccess -= ActivateOnUnsuccess;
        private void ActivateOnUnsuccess(Level level, int order) => Activate();

        public override IEnumerator PlayInAnimation()
        {
            chest.Init(SaveLoadManager.GetChestProgress());
            gameObject.SetActive(true);
            yield break;
        }

        public override IEnumerator PlayOutAnimation()
        {
            gameObject.SetActive(true);
            yield break;
        }
    }
}