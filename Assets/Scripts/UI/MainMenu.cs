using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Rhodos.Core
{
    public class MainMenu : UIScreen
    {
        [SerializeField] private Text levelCounter;
        [SerializeField] private Button playButton;

        public override void OnStart()
        {
            UpdateLevelCounter();
            PlayInAnimation();
        }

        private void UpdateLevelCounter()
        {
            //Level counter logic starts counting from 0, but user will see level sign starts from 1. 
            levelCounter.text = "Level " + (SaveLoadManager.GetLevel() + 1);
        }

        public override Sequence PlayInAnimation()
        {
            RectTransform t_levelCounter = levelCounter.GetComponent<RectTransform>();
            Vector2 oldPosOfLevelCounter = t_levelCounter.anchoredPosition;

            RectTransform t_playButton = playButton.GetComponent<RectTransform>();
            Vector2 oldPosOfPlayButton = t_playButton.anchoredPosition;

            Sequence sequence = DOTween.Sequence();
            sequence.PrependCallback((() => gameObject.SetActive(true)))
                    .Append(t_levelCounter.DOAnchorPos(oldPosOfLevelCounter, 1f).From(Vector2.up * 100f)
                                          .SetEase(Ease.OutBack).OnStart(() =>
                                              t_playButton
                                                  .DOAnchorPos(oldPosOfPlayButton, 1f).From(Vector2.down * 100f)));

            Debug.Log(oldPosOfLevelCounter);
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