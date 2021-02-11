using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Rhodos.UI
{
    using Toolkit;
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private Image image;
        [SerializeField] private float defaultDurationInSeconds;
        [SerializeField] private MinMaxPair<Vector2> positions;
        private bool _isInitialized;
        public void Init(float normalizedAmount, float defaultAnimationDurationInSec = 1f)
        {
            if (_isInitialized)
            {
                Debug.LogException(
                    new Exception("You tried to initialize a progress bar in " + gameObject.name +
                                  " when it initialized once before! Initialization canceled."), gameObject);
                return;
            }
            _isInitialized = true;
            image.fillAmount = normalizedAmount;
            defaultDurationInSeconds = defaultAnimationDurationInSec;
            gameObject.SetActive(true);
        }

        public Tween PlayInAnimation(float? duration = null)
        {
            if (!_isInitialized) Debug.LogException(
                new Exception("You tried to activate progress bar at " + gameObject.name +
                              " before it initialized. Please initialize it first!"), gameObject);
            rectTransform.anchoredPosition = positions.max;
            return rectTransform.DOAnchorPos(positions.min, duration ?? defaultDurationInSeconds);
        }

        public Tween PlayOutAnimation(float? duration = null)
        {
            if (!_isInitialized) Debug.LogException(
                new Exception("You tried to deactivate progress bar at " + gameObject.name +
                              " before it initialized. Please initialize it first!"), gameObject);
            return rectTransform.DOAnchorPos(positions.max, duration ?? defaultDurationInSeconds);
        }
        public Tween TweenProgress(float normalizedAmount, float duration)
        {
            return image.DOFillAmount(normalizedAmount, duration);
        }

        /// <summary>
        /// Sets fill amount immediately.
        /// </summary>
        public void SetProgress(float normalizedAmount)
        {
            image.fillAmount = normalizedAmount;
        }

        /// <summary>
        /// Sets image color immediately.
        /// </summary>
        public void SetImageColor(Color color)
        {
            image.color = color;
        }

        /// <summary>
        /// Tweens image color.
        /// </summary>
        public Tween TweenImageColor(Color color, float duration)
        {
            return image.DOColor(color, duration);
        }
        /// <summary>
        /// Tweens image alpha.
        /// </summary>
        /// <param name="alpha">If it is not normalized it will be.</param>
        public Tween TweenImageAlpha(float alpha, float duration)
        {
            if (alpha > 1f) alpha = 1f;
            if (alpha < 0f) alpha = 0f;
            return image.DOFade(alpha, duration);
        }
    }
}