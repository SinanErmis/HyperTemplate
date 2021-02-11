using System.Collections;
using Rhodos.Core;
using DG.Tweening;
using UnityEngine;

namespace Rhodos.UI
{
    public class FailScreen : UIScreen
    {
        public override IEnumerator PlayInAnimation()
        {
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