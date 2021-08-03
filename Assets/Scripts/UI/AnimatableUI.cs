using System;
using System.Collections;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Rhodos.UI
{
    [Serializable]
    public class AnimatableUI<T> : ISerializationCallbackReceiver where T : UIBehaviour
    {
        [field: SerializeField] public T UIComponent { get; private set; }
    
        [InfoBox("If true, game object would set false at the end of the out animation (and vice versa).")]
        [SerializeField]
        private bool changeActiveStatusWhileAnimating;
            
        [OnValueChanged("DebugAnimationType")]
        [SerializeField] private AnimationType animationType;
    
        //properties
        public Image Image => image;
        public RectTransform RectTransform => rectTransform;
        public GameObject GameObject => UIComponent.gameObject;
    
        //backing fields
        [SerializeField] [HideInInspector] private RectTransform rectTransform;
        [SerializeField] [HideInInspector] private Image image;
    
        #region Animation Params
        
        [SerializeField] [ShowIf("AnimationTypeIsMove")] [AllowNesting]
        private Vector2 inPosition;
        [SerializeField] [ShowIf("AnimationTypeIsMove")] [AllowNesting]
        private Vector2 outPosition;
        
        [SerializeField] [ShowIf("AnimationTypeIsScale")] [AllowNesting]
        private Vector3 inScale;
    
        [SerializeField] [ShowIf("AnimationTypeIsScale")] [AllowNesting]
        private Vector3 outScale;
        
        [SerializeField] [ShowIf("AnimationTypeIsFade")] [AllowNesting]
        private float inAlpha;
        [SerializeField] [ShowIf("AnimationTypeIsFade")] [AllowNesting]
        private float outAlpha;
        
        [SerializeField] [ShowIf("AnimationTypeIsColor")] [AllowNesting]
        private Color inColor;
        [SerializeField] [ShowIf("AnimationTypeIsColor")] [AllowNesting]
        private Color outColor;
    
        #endregion
    
        #region Type Checks
    
        private bool AnimationTypeIsMove => animationType.HasFlag(AnimationType.Move);
        private bool AnimationTypeIsScale => animationType.HasFlag(AnimationType.Scale);
        private bool AnimationTypeIsFade => animationType.HasFlag(AnimationType.Fade) && image != null;
        private bool AnimationTypeIsColor => animationType.HasFlag(AnimationType.Color) && image != null;
    
        #endregion
        
        #region Serialization
    
        public void OnBeforeSerialize()
        {
            if (UIComponent != null)
            {
                rectTransform = UIComponent.GetComponent<RectTransform>();
                Image image_ = UIComponent.GetComponent<Image>();
                
                if (image_ != null) image = image_;
                else image = null;
            }
            else
            {
                rectTransform = null;
                image = null;
            }
        }
    
        public void OnAfterDeserialize()
        {
        }
    
        #endregion
    
        #region Animation
    
        public IEnumerator PlayInAnimation(float duration)
        {
            if (changeActiveStatusWhileAnimating) GameObject.SetActive(true);
            if (AnimationTypeIsMove ) rectTransform.DOAnchorPos(inPosition, duration);
            if (AnimationTypeIsScale) rectTransform.DOScale(inScale, duration);
            if (AnimationTypeIsColor) Image.DOColor(inColor, duration);
            if (AnimationTypeIsFade ) Image.DOFade(inAlpha, duration);
            yield return new WaitForSeconds(duration);
        }
    
        public IEnumerator PlayOutAnimation(float duration)
        {
            if (AnimationTypeIsMove ) rectTransform.DOAnchorPos(outPosition, duration);
            if (AnimationTypeIsScale) rectTransform.DOScale(outScale, duration);
            if (AnimationTypeIsColor) Image.DOColor(outColor, duration);
            if (AnimationTypeIsFade ) Image.DOFade(outAlpha, duration);
            yield return new WaitForSeconds(duration);
            if (changeActiveStatusWhileAnimating) GameObject.SetActive(false);
        }
    
        #endregion
    
        [Flags]
        enum AnimationType
        {
            Move  = 1 << 0,
            Scale = 1 << 1,
            Fade  = 1 << 2,
            Color = 1 << 3,
        }
    
        private void DebugAnimationType()
        {
            if (animationType.HasFlag(AnimationType.Fade) && image == null)
            {
                Debug.LogError("Impossible to set animation type to Fade if object does not have Image component",
                    UIComponent);
                animationType &= ~AnimationType.Fade;
            }
    
            if (animationType.HasFlag(AnimationType.Color) && image == null)
            {
                Debug.LogError("Impossible to set animation type to Color if object does not have Image component",
                    UIComponent);
                animationType &= ~AnimationType.Color;
            }
        }
    }
}