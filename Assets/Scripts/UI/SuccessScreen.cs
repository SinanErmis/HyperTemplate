using System.Collections;
using DG.Tweening;
using MyBox;
using Rhodos.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Rhodos.UI
{
    public class SuccessScreen : UIScreen
    {
        [SerializeField] private AnimatableUI<Image> background;
        [SerializeField] private AnimatableUI<Image> emoji;
        [SerializeField] private AnimatableUI<Button> nextLevelButton;
        [SerializeField] private AnimatableUI<TextMeshProUGUI> wellPlayed;

        [SerializeField] private Sprite[] happyEmojis;
        
        public override IEnumerator PlayInAnimation()
        {
            emoji.Image.sprite = happyEmojis.GetRandom();
            gameObject.SetActive(true);
            yield return StartCoroutine(background.PlayInAnimation(1f));
            StartCoroutine(wellPlayed.PlayInAnimation(0.2f));
            yield return StartCoroutine(emoji.PlayInAnimation(0.2f));
            yield return StartCoroutine(nextLevelButton.PlayInAnimation(0.1f));
        }

        public override IEnumerator PlayOutAnimation()
        {
            gameObject.SetActive(false);
            yield break;
        }

        public void OnNextLevel()
        {
            LevelManager.RestartScene();
        }
    }
}