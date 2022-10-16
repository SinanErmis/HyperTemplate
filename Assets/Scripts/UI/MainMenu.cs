using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Rhodos.Core;
using TMPro;

namespace Rhodos.UI
{
    public class MainMenu : UIScreen
    {
        [SerializeField] private AnimatableUI<TextMeshProUGUI> levelCounter;
        [SerializeField] private AnimatableUI<Button> playButton;

        private void Start()
        {
            UpdateLevelCounter();
        }

        private void UpdateLevelCounter()
        {
            //Level counter logic starts counting from 0, but user will see level sign starts from 1. 
            levelCounter.UIComponent.text = "Level " + (SaveLoadManager.GetLevel() + 1);
        }

        public override IEnumerator PlayInAnimation()
        {
            gameObject.SetActive(true);
            StartCoroutine(levelCounter.PlayInAnimation(1f));
            yield return StartCoroutine(playButton.PlayInAnimation(1f));
        }

        public override IEnumerator PlayOutAnimation()
        {
            StartCoroutine(levelCounter.PlayOutAnimation(1f));
            yield return StartCoroutine(playButton.PlayOutAnimation(1f));
            gameObject.SetActive(false);
        }
        public void OnPlayButtonPressed()
        {
            StartCoroutine(MechanicManager.Instance.ActiveMechanic.OnStart());
        }
    }
}