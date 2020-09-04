using DG.Tweening;

namespace Rhodos.UI
{
    public class InGame : UIScreen
    {
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