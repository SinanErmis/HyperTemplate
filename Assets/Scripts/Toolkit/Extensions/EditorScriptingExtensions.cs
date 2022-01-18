#if UNITY_EDITOR
using UnityEditor;

namespace Rhodos.Toolkit.Extensions
{
    public static class EditorScriptingExtensions
    {
        public static SerializedProperty FindPropertyByAutoPropertyName(this SerializedObject obj, string propName)
        {
            return obj.FindProperty(string.Format("<{0}>k__BackingField", propName));
        }
    }
}
#endif
