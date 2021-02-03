using System;
using System.Collections;
using DG.Tweening;
using Rhodos.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Rhodos.UI
{
    /// <summary>
    /// Tutorial screen for mechanics. Must be initialized before 
    /// </summary>
    public class TutorialScreen : UIScreen
    {
        /// <summary>
        /// Overriden in Init() with no loops. It will be set as loop when it started.
        /// </summary>
        private Tween _handAnimation;
        private bool _isInitialized;
        
        [SerializeField] private Text instruction;
        private RectTransform _instructionRect;
        [field : SerializeField] public AnimationPositions InstructionPositions { get; private set; }
        
        [field : SerializeField] public RectTransform Image { get; private set; }

        public void Init(TutorialArgs arguments)
        {
            Init(arguments.Animation, arguments.Instruction);
        }
        public void Init(Tween handAnimation, string instruction)
        {
            if (_isInitialized)
            {
                Debug.LogException(
                    new Exception("You tried to initialize a tutorial screen at " + gameObject.name +
                                  " when it initialized once before! Initialization canceled."), gameObject);
                return;
            }

            _instructionRect = this.instruction.GetComponent<RectTransform>();
            _isInitialized = true;
            this.instruction.text = instruction;
            _handAnimation = handAnimation.Pause();
        }

        public void OnReset()
        {
            _handAnimation?.Kill();
            _handAnimation = null;
            _isInitialized = false;
            _instructionRect.anchoredPosition = Vector2.zero;
        }

        public override IEnumerator PlayInAnimation()
        {
            if (!_isInitialized) Debug.LogException(
                new Exception("You tried to activate tutorial screen at " + gameObject.name +
                              " before it initialized. Please initialize it first!"), gameObject);
            gameObject.SetActive(true);
            _handAnimation.Play().SetLoops(-1, LoopType.Yoyo);
            yield return _instructionRect.DOAnchorPos(InstructionPositions.inPlace, 1f).WaitForCompletion();
        }

        public override IEnumerator PlayOutAnimation()
        {
            if (!_isInitialized) Debug.LogException(
                new Exception("You tried to deactivate tutorial screen at " + gameObject.name +
                              " before it initialized. Please initialize it first!"), gameObject);
            _handAnimation?.Kill();
            yield return _instructionRect.DOAnchorPos(InstructionPositions.outPlace, 1f).WaitForCompletion();
            gameObject.SetActive(false);
        }
    }
}