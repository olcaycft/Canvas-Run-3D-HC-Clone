using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Patterns
{
    public class ObjectPooler : MonoSingleton<ObjectPooler>
    {
        public List<Pool> pools;
        public Dictionary<string, Queue<GameObject>> poolDictionary;

        private void Awake()
        {
            poolDictionary = new Dictionary<string, Queue<GameObject>>();

            #region FillQueues

            foreach (var pool in pools)
            {
                Queue<GameObject> objectPool = new Queue<GameObject>();
                for (int i = 0; i < pool.size; i++)
                {
                    GameObject obj = Instantiate(pool.prefab);
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                }

                poolDictionary.Add(pool.tag, objectPool);
            }

            #endregion
        }

        public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
        {
            if (!poolDictionary.ContainsKey(tag)) //if there is no compared tag in our dictionary return null 
            {
                Debug.Log("Pool with tag" + tag + "doesnt exist");
                return null;
            }

            GameObject objToSpawn = poolDictionary[tag].Dequeue();

            objToSpawn.SetActive(true);
            objToSpawn.transform.position = position;
            objToSpawn.transform.rotation = rotation;

           /* IOnUnitSpawn pooledObj = objToSpawn.GetComponent<IOnUnitSpawn>();
            if (pooledObj != null)
            {
                pooledObj.OnUnitSpawn();
            }*/

            poolDictionary[tag].Enqueue(objToSpawn);
            return objToSpawn;
        }
    }

    #region PoolClass

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    #endregion
}