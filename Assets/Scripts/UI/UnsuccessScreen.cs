using Rhodos.Core;
using DG.Tweening;
using UnityEngine;

namespace Rhodos.UI
{
    public class UnsuccessScreen : UIScreen
    {
        [SerializeField] private Chest chest;
        //TODO chest initilization/opening changes foreach game.
        
        public override void SubscribeEvents() => CentralEventManager.OnUnsuccess += ActivateOnUnsuccess;
        public override void UnsubscribeEvents() => CentralEventManager.OnUnsuccess -= ActivateOnUnsuccess;
        private void ActivateOnUnsuccess(Level level, int order) => Activate();

        public override Sequence PlayInAnimation()
        {
            chest.Init(SaveLoadManager.GetChestProgress());
            Sequence sequence = DOTween.Sequence();
            sequence.PrependCallback(() =>
            {
                gameObject.SetActive(true);
            });
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