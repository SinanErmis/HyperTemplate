using System.Collections.Generic;
using UnityEngine;

namespace Rhodos.Toolkit
{
    public class GameObjectPool
    {
        private readonly GameObject _prefab;
        private readonly List<GameObject> _objectPool = new List<GameObject>();

        public GameObjectPool(GameObject prefab)
        {
            _prefab = prefab;
        }

        public void LoadPool(int number)
        {
            for (int i = 0; i < number; i++)
            {
                GameObject gameObject = Object.Instantiate(_prefab);
                AddObject(gameObject);
            }
        }

        public GameObject[] GetAll()
        {
            return _objectPool.ToArray();
        }

        public GameObject GetObject()
        {
            if (_objectPool.Count > 0)
            {
                GameObject gameObject = _objectPool[_objectPool.Count - 1];
                _objectPool.RemoveAt(_objectPool.Count - 1);
                gameObject.SetActive(true);

                return gameObject;
            }

            return Object.Instantiate(_prefab);
        }

        public GameObject GetObjectWithoutActivating()
        {
            if (_objectPool.Count > 0)
            {
                GameObject gameObject = _objectPool[_objectPool.Count - 1];
                _objectPool.RemoveAt(_objectPool.Count - 1);

                return gameObject;
            }

            return Object.Instantiate(_prefab);
        }

        public void AddObject(GameObject gameObject)
        {
            gameObject.SetActive(false);
            _objectPool.Insert(0, gameObject);
        }
    }
}