using Rhodos.Toolkit;
using UnityEditor;
using UnityEngine;

namespace Rhodos.Editor
{
    /// <summary>
    /// Draws the generic dictionary a bit nicer than Unity would natively (not as many expand-arrows
    /// and better spacing between KeyValue pairs). Also renders a warning-box if there are duplicate
    /// keys in the dictionary.
    /// </summary>
    [CustomPropertyDrawer(typeof(GenericDictionary<,>))]
    public class GenericDictionaryPropertyDrawer : PropertyDrawer
    {
        private static readonly float LineHeight = EditorGUIUtility.singleLineHeight;
        private static readonly float VertSpace = EditorGUIUtility.standardVerticalSpacing;

        public override void OnGUI(Rect pos, SerializedProperty property, GUIContent label)
        {
            // Draw list.
            var list = property.FindPropertyRelative("list");
            string fieldName = ObjectNames.NicifyVariableName(fieldInfo.Name);
            var currentPos = new Rect(LineHeight, pos.y, pos.width, LineHeight);
            EditorGUI.PropertyField(currentPos, list, new GUIContent(fieldName), true);

            // Draw key collision warning.
            var keyCollision = property.FindPropertyRelative("keyCollision").boolValue;
            if (keyCollision)
            {
                currentPos.y += EditorGUI.GetPropertyHeight(list, true) + VertSpace;
                var entryPos = new Rect(LineHeight, currentPos.y, pos.width, LineHeight * 2f);
                EditorGUI.HelpBox(entryPos, "Duplicate keys will not be serialized.", MessageType.Warning);
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            float totHeight = 0f;

            // Height of KeyValue list.
            var listProp = property.FindPropertyRelative("list");
            totHeight += EditorGUI.GetPropertyHeight(listProp, true);

            // Height of key collision warning.
            bool keyCollision = property.FindPropertyRelative("keyCollision").boolValue;
            if (keyCollision)
            {
                totHeight += LineHeight * 2f + VertSpace;
            }

            return totHeight;
        }
    }

}