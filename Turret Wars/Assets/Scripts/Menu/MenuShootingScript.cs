using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuShootingScript : MonoBehaviour
{

    public RectTransform bulletSpawnPointOne;
    public RectTransform bulletSpawnPointTwo;

    public RectTransform tankSpawnPointOne;
    public RectTransform tankSpawnPointTwo;
    public Sprite tankSprite;

    public RectTransform creepSpawnPointOne;
    public RectTransform creepSpawnPointTwo;
    public Sprite creepSprite;

    public GameObject dgo;

    private ObjectPool<MenuBulletBehaviour> bullets;
    private ObjectPool<MenuBulletBehaviour> tanks;
    private ObjectPool<MenuBulletBehaviour> creeps;
    private GameObject canvas;

    // Use this for initialization
    void Start()
    {
        bullets = new ObjectPool<MenuBulletBehaviour>(dgo);
        tanks = new ObjectPool<MenuBulletBehaviour>(dgo);
        creeps = new ObjectPool<MenuBulletBehaviour>(dgo);

        tanks.SetImage(tankSprite);
        creeps.SetImage(creepSprite);

        canvas = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        // Bullets
        if( Random.value > 0.97f)
        {
            if (Random.value > 0.5f)
            {
                var b = bullets.Create(null, 0, bulletSpawnPointOne.position) as MenuBulletBehaviour;
                b.TargetPos = bulletSpawnPointTwo.position;
                b.Fire();
                b.transform.parent = canvas.transform;
                b.transform.rotation = Quaternion.identity;
            }
            else
            {
                var b = bullets.Create(null, 0, bulletSpawnPointTwo.position) as MenuBulletBehaviour;
                b.TargetPos = bulletSpawnPointOne.position;
                b.Fire();
                b.transform.parent = canvas.transform;
                b.transform.rotation = Quaternion.identity;
            }
        }

        // Tanks
        if (Random.value > 0.99f)
        {
            if (Random.value > 0.5f)
            {
                var b = tanks.Create(null, 0, tankSpawnPointOne.position) as MenuBulletBehaviour;
                b.Speed = 30;
                b.TargetPos = tankSpawnPointTwo.position;
                b.Fire();
                b.transform.parent = canvas.transform;
                b.transform.SetSiblingIndex(2);
                b.transform.rotation = Quaternion.identity;
            }
            else
            {
                var b = tanks.Create(null, 0, tankSpawnPointTwo.position) as MenuBulletBehaviour;
                b.Speed = 30;
                b.TargetPos = tankSpawnPointOne.position;
                b.Fire();
                b.transform.parent = canvas.transform;
                b.transform.SetSiblingIndex(2);
                b.transform.rotation = Quaternion.identity;
            }
        }

        // creeps
        if (Random.value > 0.98f)
        {
            if (Random.value > 0.5f)
            {
                var b = creeps.Create(null, 0, creepSpawnPointOne.position) as MenuBulletBehaviour;
                b.Speed = 50;
                b.TargetPos = creepSpawnPointTwo.position;
                b.Fire();
                b.transform.parent = canvas.transform;
                b.transform.SetSiblingIndex(2);
                b.transform.rotation = Quaternion.identity;
            }
            else
            {
                var b = creeps.Create(null, 0, creepSpawnPointTwo.position) as MenuBulletBehaviour;
                b.Speed = 50;
                b.TargetPos = creepSpawnPointOne.position;
                b.Fire();
                b.transform.parent = canvas.transform;
                b.transform.SetSiblingIndex(2);
                b.transform.rotation = Quaternion.identity;
            }
        }
    }
}
