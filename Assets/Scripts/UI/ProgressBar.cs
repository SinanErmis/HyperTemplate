using System;
using DG.Tweening;
using Rhodos.Toolkit.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace Rhodos.UI
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private Image image;
        [SerializeField] private float animationDurationInSeconds = 1f;
        [SerializeField] private AnimationPositions positions;
        private bool _isInitialized;
        public void Init(float normalizedAmount, float animationDuration = 1f)
        {
            if (_isInitialized)
            {
                Debug.LogException(
                    new Exception("You tried to initialize a progress screen in " + gameObject.name +
                                  " when it initialized once before! Initialization canceled."), gameObject);
                return;
            }
            _isInitialized = true;
            image.fillAmount = normalizedAmount;
            animationDurationInSeconds = animationDuration;
            gameObject.SetActive(true);
        }

        public Tween PlayInAnimation()
        {
            if (!_isInitialized) Debug.LogException(
                    new Exception("You tried to activate progress bar at " + gameObject.name +
                                  " before it initialized. Please initialize it first!"), gameObject);
            return rectTransform.DOMove(positions.inPlace, animationDurationInSeconds);
        }

        public Tween PlayOutAnimation()
        {
            if (!_isInitialized) Debug.LogException(
                new Exception("You tried to deactivate progress bar at " + gameObject.name +
                              " before it initialized. Please initialize it first!"), gameObject);
            return rectTransform.DOMove(positions.outPlace, animationDurationInSeconds);
        }
        public Tween SetProgress(float normalizedAmount)
        {
            float now = image.fillAmount;
            return image.DOFillAmount(normalizedAmount, (normalizedAmount - now).Abs());
        }
    }
}