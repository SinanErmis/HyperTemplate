using System.Collections;
using DG.Tweening;
using Rhodos.Core;
using UnityEngine;

namespace Rhodos.UI
{
    public class SuccessScreen : UIScreen
    {
        [SerializeField] private Chest chest;
        //TODO chest initilization/opening changes foreach game.

        public override void SubscribeEvents() => CentralEventManager.OnSuccess += ActivateOnSuccess;
        public override void UnsubscribeEvents() => CentralEventManager.OnSuccess -= ActivateOnSuccess;
        private void ActivateOnSuccess(Level level, int order) => Activate();

        public override IEnumerator PlayInAnimation()
        {
            chest.Init(0.5f);
            gameObject.SetActive(true);
            yield break;
        }

        public override IEnumerator PlayOutAnimation()
        {
            gameObject.SetActive(false);
            yield break;
        }
    }
}