using System.Collections.Generic;
using UnityEngine;

namespace RhythmGame.Data
{
    public class ObjectPool
    {
        private GameObject _prefab;
        private List<GameObject> _pool;

        public ObjectPool(GameObject prefab, int poolSize)
        {
            _prefab = prefab;
            _pool = new List<GameObject>();

            for (int i = 0; i < poolSize; i++)
            {
                CreatePool();
            }
        }

        private void CreatePool()
        {
            GameObject obj = GameObject.Instantiate(_prefab);
            obj.SetActive(false);
            _pool.Add(obj);
        }

        public GameObject GetPool()
        {
            foreach (var obj in _pool)
            {
                if (!obj.activeInHierarchy)
                {
                    obj.SetActive(true);
                    return obj;
                }
            }
            
            CreatePool();
            return GetPool();
        }
    }
}