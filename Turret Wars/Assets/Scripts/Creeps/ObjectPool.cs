using UnityEngine;
using System.Collections;

public class ObjectPool<T> where T : IPoolable, new() {
    
    public int PoolSize;

    private T[] pool;

    public ObjectPool(GameObject dummyGameObject)
    {
        PoolSize = 300;
        dummyGameObject.AddComponent<T>();
        pool = new T[PoolSize];
        for (int i = 0; i < PoolSize; i++)
        {
            GameObject go = MonoBehaviour.Instantiate(Resources.Load(dummyGameObject.GetComponent<T>().ToString(), typeof(GameObject))) as GameObject;
            go.AddComponent<T>();

            pool[i] = go.GetComponent<T>();
        }
    }

    public IPoolable Create(Player creator, uint objectId)
    {
        foreach (T obj in pool)
            if (!obj.InUse) return obj.Create(creator, objectId);
        Debug.Log("No creatures to pull from object pool.");
        return null;
    }
}
