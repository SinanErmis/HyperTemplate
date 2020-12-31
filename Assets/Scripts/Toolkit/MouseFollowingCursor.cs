using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace Rhodos.Toolkit
{
    //TODO: Create a full functional mouse following cursor canvas prefab. 
    public class MouseFollowingCursor : MonoBehaviour
    {
        [SerializeField] private Image cursorImage;
        [SerializeField] private Sprite defaultCursorSprite;
        [SerializeField] private Sprite pressedCursorSprite;
        [SerializeField] private Transform highlightTransform;
        [SerializeField] private Canvas canvas;

        private void Start()
        {
            highlightTransform.SetParent(canvas.transform);
        }
        private void Update()
        {
            transform.position = Input.mousePosition;

            if (Input.GetMouseButtonDown(0))
            {
                cursorImage.sprite = pressedCursorSprite;

                highlightTransform.position = transform.position;

                DOTween.Restart("cursor_highlight");
            }

            if (Input.GetMouseButtonUp(0))
            {
                cursorImage.sprite = defaultCursorSprite;
            }
        }


    }
}