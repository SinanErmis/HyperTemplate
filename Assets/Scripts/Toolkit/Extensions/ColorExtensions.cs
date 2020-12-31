using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Rhodos.Toolkit.Extensions
{
    public static class ColorExtensions
    {
        public static void MakeTransparent(this TextMeshProUGUI text)
        {
            //  text.overrideColorTags = true;
            Color color = text.color;
            color.a = 0f;
            text.color = color;
        }

        public static void MakeTransparent(this ref Color color)
        {
            Color tempColor = color;
            tempColor.a = 0f;
            color = tempColor;
        }

        public static void MakeTransparent(this Text text)
        {
            Color c = text.color;
            c.a = 0f;
            text.color = c;
        }

        public static void MakeOpaque(this ref Color color)
        {
            Color tempColor = color;
            tempColor.a = 1f;
            color = tempColor;
        }

        public static void MakeOpaque(this TextMeshProUGUI image)
        {
            Color color = image.faceColor;
            color.a = 1f;
            image.faceColor = color;
        }

        public static void MakeTransparent(this Image image)
        {
            Color color = image.color;
            color.a = 0f;
            image.color = color;
        }

        public static void MakeOpaque(this Image image)
        {
            Color color = image.color;
            color.a = 1f;
            image.color = color;
        }
    }
}