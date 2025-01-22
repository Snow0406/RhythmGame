using System.Collections.Generic;
using UnityEngine;

namespace RhythmGame.Data
{
    public class ObjectPool
    {
        private GameObject prefab;
        private List<GameObject> pool;

        public ObjectPool(GameObject prefab, int poolSize)
        {
            this.prefab = prefab;
            this.pool = new List<GameObject>();

            for (int i = 0; i < poolSize; i++)
            {
                CreatePool();
            }
        }

        private void CreatePool()
        {
            GameObject obj = GameObject.Instantiate(prefab);
            obj.SetActive(false);
            pool.Add(obj);
        }

        public GameObject GetPool()
        {
            foreach (var obj in pool) 
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