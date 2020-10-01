using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Rhodos.Core;

namespace Rhodos.UI
{
    public class MainMenu : UIScreen
    {
        [SerializeField] private Text levelCounter;
        [SerializeField] private Button playButton;

        public override void OnStart()
        {
            UpdateLevelCounter();
            Activate();
        }

        private void UpdateLevelCounter()
        {
            //Level counter logic starts counting from 0, but user will see level sign starts from 1. 
            levelCounter.text = "Level " + (SaveLoadManager.GetLevel() + 1);
        }

        public override IEnumerator PlayInAnimation()
        {
            RectTransform t_levelCounter = levelCounter.GetComponent<RectTransform>();
            Vector2 oldPosOfLevelCounter = t_levelCounter.anchoredPosition;

            RectTransform t_playButton = playButton.GetComponent<RectTransform>();
            Vector2 oldPosOfPlayButton = t_playButton.anchoredPosition;

            gameObject.SetActive(true);
            t_levelCounter.DOAnchorPos(oldPosOfLevelCounter, 1f).From(Vector2.up * 100f).SetEase(Ease.OutBack);
            t_playButton.DOAnchorPos(oldPosOfPlayButton, 1f).From(Vector2.down * 100f);
            yield return new WaitForSecondsRealtime(1f);
        }

        public override IEnumerator PlayOutAnimation()
        {
            gameObject.SetActive(false);
            yield break;
        }
    }
}