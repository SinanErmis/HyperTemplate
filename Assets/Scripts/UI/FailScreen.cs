using System.Collections;
using Rhodos.Core;
using DG.Tweening;
using MyBox;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Rhodos.UI
{
    public class FailScreen : UIScreen
    {
        [SerializeField] private AnimatableUI<Image> background;
        [SerializeField] private AnimatableUI<Image> sadEmoji;
        [SerializeField] private AnimatableUI<Button> retryButton;
        [SerializeField] private AnimatableUI<TextMeshProUGUI> gameOver;
        
        [SerializeField] private Sprite[] sadEmojis;
        
        public override IEnumerator PlayInAnimation()
        {
            sadEmoji.Image.sprite = sadEmojis.GetRandom();
            gameObject.SetActive(true);
            yield return StartCoroutine(background.PlayInAnimation(1f));
            StartCoroutine(gameOver.PlayInAnimation(0.2f));
            yield return StartCoroutine(sadEmoji.PlayInAnimation(0.2f));
            yield return StartCoroutine(retryButton.PlayInAnimation(0.1f));
        }

        public override IEnumerator PlayOutAnimation()
        {
            gameObject.SetActive(false);
            yield break;
        }

        public void OnRetry()
        {
            LevelManager.RestartScene();
        }
    }
}