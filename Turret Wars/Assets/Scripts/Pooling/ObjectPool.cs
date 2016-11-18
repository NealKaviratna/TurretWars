using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ObjectPool<T> where T : Poolable, new()
{

    public int PoolSize;

    private T[] pool;

    public ObjectPool(GameObject dummyGameObject)
    {
        PoolSize = 100;
        dummyGameObject.AddComponent<T>();
        pool = new T[PoolSize];
        for (int i = 0; i < PoolSize; i++)
        {
            GameObject go = MonoBehaviour.Instantiate(Resources.Load(dummyGameObject.GetComponent<T>().ToString(), typeof(GameObject))) as GameObject;
            go.AddComponent<T>();

            pool[i] = go.GetComponent<T>();
        }
    }

    public Poolable Create(Player creator, uint objectId, Vector3 position)
    {
        foreach (T obj in pool)
            if (!obj.InUse) return obj.Create(creator, objectId, position);
        Debug.Log("No objects to pull from object pool.");
        return null;
    }

    // Hackey thing made for menu use
    public void SetImage(Sprite image)
    {
        foreach (T t in pool)
        {
            t.GetComponentInChildren<Image>().sprite = image;
            Color[] colors = { Color.red, Color.green, Color.yellow };
            t.GetComponentInChildren<Image>().color = colors[Random.Range(0, 3)];
            t.GetComponentInChildren<Image>().rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 5);
            t.GetComponentInChildren<Image>().rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 500);
        }
    } 
}
