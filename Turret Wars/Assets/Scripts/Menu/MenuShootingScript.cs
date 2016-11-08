using UnityEngine;
using System.Collections;

public class MenuShootingScript : MonoBehaviour
{

    public RectTransform spawnPointOne;
    public RectTransform spawnPointTwo;

    public GameObject dgo;

    private ObjectPool<MenuBulletBehaviour> bullets;
    private GameObject canvas;

    // Use this for initialization
    void Start()
    {
        bullets = new ObjectPool<MenuBulletBehaviour>(dgo);
        canvas = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        if( Random.value > 0.99f)
        {
            if (Random.value > 0.5f)
            {
                var b = bullets.Create(null, 0, spawnPointOne.position) as MenuBulletBehaviour;
                b.TargetPos = spawnPointTwo.position;
                b.Fire();
                b.transform.parent = canvas.transform;
                b.transform.rotation = Quaternion.identity;
            }
            else
            {
                var b = bullets.Create(null, 0, spawnPointTwo.position) as MenuBulletBehaviour;
                b.TargetPos = spawnPointOne.position;
                b.Fire();
                b.transform.parent = canvas.transform;
                b.transform.rotation = Quaternion.identity;
            }
        }
    }
}
