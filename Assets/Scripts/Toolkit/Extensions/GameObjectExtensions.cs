using UnityEngine;

namespace Rhodos.Toolkit.Extensions
{
    public static class GameObjectExtensions
    {
        public static GameObject Instantiate(this GameObject prefab)
        {
            return Object.Instantiate(prefab);
        }
        public static GameObject InstantiateLike(this GameObject prefab, Transform transformInfo)
        {
            return Object.Instantiate(prefab, transformInfo.position, transformInfo.rotation);
        }

        public static GameObject InstantiateLike(this GameObject prefab, Transform transformInfo, Transform parent)
        {
            return Object.Instantiate(prefab, transformInfo.position, transformInfo.rotation, parent);
        }
        public static GameObject Instantiate(this GameObject prefab, Transform parent)
        {
            return Object.Instantiate(prefab, parent, false);
        }
        
        public static T Instantiate<T>(this T prefab) where T: Object
        {
            return Object.Instantiate<T>(prefab);
        }
    }
}