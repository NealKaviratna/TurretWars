using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

public class BasicMachineGun : Weapon
{

    public Player Player;
    public Transform MuzzleTrans;

    private ObjectPool<BasicBulletBehaviour> bulletPool;

    private float timer;

    // Use this for initialization
    protected override void Awake()
    {
        this.level = 0;
        this.fireRate = 0.1f;
        this.timer = this.fireRate;

        var DummyGameObject = Instantiate(Resources.Load("dgo")) as GameObject;
        bulletPool = new ObjectPool<BasicBulletBehaviour>(DummyGameObject);

        this.upgradeUISetup();

        base.Awake();
    }



    private void upgradeUISetup()
    {
        this.upgradeIcon = GameObject.Find("UI:MachineGun").transform.GetChild(0).GetComponent<Image>();
        this.upgradeSprites = new System.Collections.Generic.Queue<Sprite>();
        for (int i = 1; i < 4; i++)
            this.upgradeSprites.Enqueue(Resources.Load<Sprite>("UpgradeIcon") as Sprite);
        this.upgradeSprites.Enqueue(Resources.Load<Sprite>("IceUpgradeIcon") as Sprite);
        for (int i = 5; i < 10; i++)
            this.upgradeSprites.Enqueue(Resources.Load<Sprite>("UpgradeIcon") as Sprite);
    }

    public override void Fire()
    {
        RaycastHit hitInfo;
        int layerMask = ~(1 << 5);
        BulletBehaviour b = bulletPool.Create(Player, 0, MuzzleTrans.position) as BulletBehaviour;
        if (Physics.Raycast(Player.transform.position, Player.transform.forward, out hitInfo, 1000 ,layerMask))
        {
            //Debug.Log("hitting: " + hitInfo.collider.gameObject.ToString());
            b.TargetPos = hitInfo.point;
        }
        else
        {
            b.TargetPos = MuzzleTrans.position + this.transform.parent.forward;
        }

        if (this.effect != null)
        {
            b.Effect = this.effect;
            if (this.effect.hasColor)
                this.effect.SetTargetColor(b.gameObject);
        }

        b.Fire();
        base.Fire();
    }

    protected override void Update()
    {
        if (!gameObject.transform.parent.gameObject.GetComponent<NetworkIdentity>().isLocalPlayer) return;

        this.timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Mouse0) && (this.fireRate <= this.timer))
        {
            Fire();
            this.timer = 0.0f;
        }
        base.Update();
    }

    public override void LevelUp()
    {
        switch (this.level++)
        {
            case 4:
                this.effect = gameObject.AddComponent<FrostEffectBehaviour>();
                break;
            default:
                this.fireRate -= 0.05f;
                break;
        }
        base.LevelUp();
    }
}
