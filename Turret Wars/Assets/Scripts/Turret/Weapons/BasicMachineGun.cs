using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class BasicMachineGun : Weapon
{

    public Player Player;
    public Transform MuzzleTrans;

    private ObjectPool<BasicBulletBehaviour> bulletPool;

    private EffectBehaviour effect;

    private float timer;

    // Use this for initialization
    void Start()
    {
        this.level = 0;
        this.fireRate = 0.1f;
        this.timer = 0.0f;
        var DummyGameObject = Instantiate(Resources.Load("dgo")) as GameObject;
        bulletPool = new ObjectPool<BasicBulletBehaviour>(DummyGameObject);
    }
    
    public override void Fire()
    {
        RaycastHit hitInfo; ;

        BulletBehaviour b = bulletPool.Create(Player, 0, MuzzleTrans.position) as BulletBehaviour;
        if (Physics.Raycast(MuzzleTrans.position, this.transform.forward, out hitInfo))
        {
            b.TargetPos = hitInfo.point;
            b.Target = hitInfo.transform.gameObject;
        }

        if (this.effect != null)
            b.Effect = this.effect;

        b.Fire();
    }

    public void Update()
    {
        if (!gameObject.transform.parent.gameObject.GetComponent<NetworkIdentity>().isLocalPlayer) return;

        this.timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Mouse0) && (this.fireRate <= this.timer))
        {
            Fire();
            this.timer = 0.0f;
        }
        if (Input.GetKeyDown(KeyCode.U))
            LevelUp();
    }

    public void LevelUp()
    {
        switch (this.level++)
        {
            case 0:
                this.fireRate -= 0.1f;
                break;
            case 1:
                this.effect = gameObject.AddComponent<FrostEffectBehaviour>();
                break;
            default:
                this.fireRate -= 0.1f;
                break;
        }
    }
}
