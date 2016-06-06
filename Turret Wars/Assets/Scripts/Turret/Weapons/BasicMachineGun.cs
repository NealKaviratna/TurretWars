using UnityEngine;
using System.Collections;

public class BasicMachineGun : Weapon {

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

    }
}
