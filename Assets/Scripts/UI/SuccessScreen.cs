using DG.Tweening;
using UnityEngine;

namespace Rhodos.Core
{
    public class SuccessScreen : UIScreen
    {
        [SerializeField] private Chest chest;
        //TODO chest initilization/opening changes foreach game.

        public override Sequence PlayInAnimation()
        {
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