using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Rhodos.Core
{
    /// <summary>
    /// In progress.
    /// </summary>
    public class Chest : MonoBehaviour
    {
        private Image _image;
        [SerializeField] private RectTransform box;
        [SerializeField] private RectTransform background;
        private Tween _scaleAnimation;

        private void Awake()
        {
            _image = box.GetComponent<Image>();
            
            //Start "idle" animation
            background.DORotate(new Vector3(0, 0, 5f), 1f).SetEase(Ease.Linear).SetRelative(true)
                      .SetLoops(-1, LoopType.Incremental);
            _scaleAnimation = box.DOScale(Vector3.one * 1.05f, 0.6f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        }

        public void Init(float startingFillAmount)
        {
            _image.fillAmount = startingFillAmount;
        }
        
        #if UNITY_EDITOR
        private void Update() //For debugging easily
        {
            if (Input.GetMouseButtonDown(0)) Fill(0.1f);
            else if (Input.GetMouseButtonDown(1)) Fill(-0.10f);
        }
        #endif

        public Coroutine Fill(float addition)
        {
            return StartCoroutine(CoFill());

            IEnumerator CoFill()
            {
                if (_image.fillAmount + addition < 1)
                    yield return _image.DOFillAmount(_image.fillAmount + addition, Math.Abs(addition));
                else
                {
                    float firstStep = 1f - _image.fillAmount;
                    float secondStep = addition - firstStep;

                    yield return _image.DOFillAmount(firstStep, firstStep);
                    _scaleAnimation.Pause();

                    yield return StartCoroutine(OpenChest());

                    _image.fillAmount = 0f;
                    yield return _image.DOFillAmount(secondStep, secondStep);

                    _scaleAnimation.Play();
                }
            }
        }

        private IEnumerator OpenChest() //Just change OpenChest method for applying another animation.
        {
            yield return box.DOShakeRotation(1.5f, Vector3.forward * 10f);

            //TODO open chest
            Debug.Log("Chest Opened");
        }
    }
}