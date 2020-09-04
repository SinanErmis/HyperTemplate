using System.Collections.Generic;
using UnityEngine;

namespace Rhodos.Toolkit
{
    public class MonoBehaviourPool<T> where T : MonoBehaviour
    {
        private readonly T _prefab;
        private readonly List<T> _objectPool = new List<T>();


        public MonoBehaviourPool(T prefab)
        {
            _prefab = prefab;
        }

        public void LoadPool(int number)
        {
            for (int i = 0; i < number; i++)
            {
                T gameObject = Object.Instantiate(_prefab);
                AddObject(gameObject);
            }
        }

        public T[] GetAll()
        {
            return _objectPool.ToArray();
        }

        public T GetObject()
        {
            if (_objectPool.Count > 0)
            {
                T gameObject = _objectPool[_objectPool.Count - 1];
                _objectPool.RemoveAt(_objectPool.Count - 1);
                gameObject.gameObject.SetActive(true);

                return gameObject;
            }

            return Object.Instantiate(_prefab);
        }

        public T GetObjectWithoutActivating()
        {
            if (_objectPool.Count > 0)
            {
                T gameObject = _objectPool[_objectPool.Count - 1];
                _objectPool.RemoveAt(_objectPool.Count - 1);

                return gameObject;
            }

            return Object.Instantiate(_prefab);
        }

        public void AddObject(T gameObject)
        {
            gameObject.gameObject.SetActive(false);
            _objectPool.Insert(0, gameObject);
        }

    }
}