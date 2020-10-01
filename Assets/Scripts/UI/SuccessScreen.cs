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

        public override Sequence PlayInAnimation()
        {
            chest.Init(0.5f);
            Sequence sequence = DOTween.Sequence();
            sequence.PrependCallback((() => gameObject.SetActive(true)));
            return sequence;
        }

        public override Sequence PlayOutAnimation()
        {
            Sequence sequence = DOTween.Sequence();
            sequence.AppendCallback((() => gameObject.SetActive(false)));
            return sequence;
        }
    }
}