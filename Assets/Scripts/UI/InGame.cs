using System.Collections;
using DG.Tweening;

namespace Rhodos.UI
{
    public class InGame : UIScreen
    {
        public override IEnumerator PlayInAnimation()
        {
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