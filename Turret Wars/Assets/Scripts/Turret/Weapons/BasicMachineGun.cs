using UnityEngine;
using System.Collections;

public class BasicMachineGun : Weapon {

    public Player Player;
    public Transform MuzzleTrans;

    private ObjectPool<BasicBulletBehaviour> bulletPool;

	// Use this for initialization
	void Start () {
        this.level = 0;
        this.fireRate = 0.5f;
        var DummyGameObject = Instantiate(Resources.Load("dgo")) as GameObject;
        bulletPool = new ObjectPool<BasicBulletBehaviour>(DummyGameObject);
    }

    public override void Fire()
    {
        RaycastHit hitInfo;;

        BulletBehaviour b = bulletPool.Create(Player, 0, MuzzleTrans.position) as BulletBehaviour;
        if (Physics.Raycast(MuzzleTrans.position, this.transform.forward, out hitInfo))
        {
            b.TargetPos = hitInfo.point;
            b.Target = hitInfo.transform.gameObject;
        }
        b.Fire();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Fire();
    }
}
