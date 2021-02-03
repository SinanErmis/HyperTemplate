using System;
using System.Collections;
using System.Globalization;
using DG.Tweening;
using Rhodos.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Rhodos.UI
{
    /// <summary>
    /// TODO In progress (refactor).
    /// </summary>
    public class Chest : MonoBehaviour
    {
        [SerializeField] private Image chestImage;
        [SerializeField] private RectTransform chestTransform;
        [SerializeField] private RectTransform background;
        [SerializeField] private Text fillAmountIndicator;
        private Tween _scaleAnimation;

        private void Awake()
        {
            //Start "idle" animation
            background.DORotate(new Vector3(0, 0, 5f), 1f).SetEase(Ease.Linear).SetRelative(true)
                      .SetLoops(-1, LoopType.Incremental);
            _scaleAnimation = chestTransform.DOScale(Vector3.one * 1.05f, 0.6f).SetLoops(-1, LoopType.Yoyo)
                                            .SetEase(Ease.Linear);
        }

        public void Init()
        {
            Init(GetChestProgress());
        }
        public void Init(float startingFillAmount)
        {
            chestImage.fillAmount = startingFillAmount;
            fillAmountIndicator.text = "%" + Math.Round(startingFillAmount * 100f);
        }
        
        public IEnumerator Fill(float addition)
        {
            bool isEqual = Mathf.RoundToInt(100f * (chestImage.fillAmount + addition)) == 100;

            if (chestImage.fillAmount + addition < 1 && !isEqual)
            {
                yield return chestImage.DOFillAmount(chestImage.fillAmount + addition, Math.Abs(addition))
                                       .OnUpdate(() =>
                                           fillAmountIndicator.text =
                                               "%" + Mathf.RoundToInt(chestImage.fillAmount * 100f))
                                       .OnStart(() => IncreaseChestProgress(addition));
            }
            else if (isEqual)
            {
                yield return chestImage.DOFillAmount(1f, Math.Abs(addition))
                                       .OnUpdate(() =>
                                           fillAmountIndicator.text =
                                               "%" + Mathf.RoundToInt(chestImage.fillAmount * 100f))
                                       .OnStart(() => IncreaseChestProgress(addition));
                _scaleAnimation.Pause();

                yield return StartCoroutine(OpenChest());

                fillAmountIndicator.text = "%0";
                chestImage.fillAmount = 0f;

                _scaleAnimation.Play();
            }
            else
            {
                float firstStep = 1f - chestImage.fillAmount;
                float secondStep = addition - firstStep;

                yield return chestImage.DOFillAmount(firstStep, firstStep)
                                       .OnUpdate(() =>
                                           fillAmountIndicator.text =
                                               "%" + Mathf.RoundToInt(chestImage.fillAmount * 100f))
                                       .OnStart(() => IncreaseChestProgress(addition));
                _scaleAnimation.Pause();

                yield return StartCoroutine(OpenChest());

                chestImage.fillAmount = 0f;
                fillAmountIndicator.text = "%0";
                yield return chestImage.DOFillAmount(secondStep, secondStep)
                                       .OnUpdate(() =>
                                           fillAmountIndicator.text =
                                               "%" + Mathf.RoundToInt(chestImage.fillAmount * 100f))
                                       .OnStart(() => IncreaseChestProgress(addition));
                _scaleAnimation.Play();
            }
        }

        private IEnumerator OpenChest() //Just change OpenChest method for applying another animation.
        {
            yield return chestTransform.DOShakeRotation(1.5f, Vector3.forward * 10f, fadeOut: false)
                                       .OnComplete(() => chestTransform.DORotate(Vector3.zero, 0.02f));
            
            //TODO chest opening anim
            Debug.Log("Chest Opened");
        }

        private const string CHEST_KEY = "ChestProgress";
        public static float GetChestProgress() => PlayerPrefs.GetFloat(CHEST_KEY, 0f);
        public static void IncreaseChestProgress(float amount) =>
            PlayerPrefs.SetFloat(CHEST_KEY, GetChestProgress() + amount);
        public static void SetChestProgress(float amount) => PlayerPrefs.SetFloat(CHEST_KEY, amount);
    }
}