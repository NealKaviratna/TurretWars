using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Networking;

public class SuperShotgun : Weapon
{

    public Player Player;
    public Transform MuzzleTrans;
    public int PelletCount;

    private ObjectPool<ShotgunPelletBehaviour> bulletPool;

    private float timer;

    // Use this for initialization
    protected override void Awake()
    {
        this.level = 0;
        this.fireRate = 0.5f;
        this.timer = this.fireRate;

        var DummyGameObject = Instantiate(Resources.Load("dgo")) as GameObject;
        bulletPool = new ObjectPool<ShotgunPelletBehaviour>(DummyGameObject);

        this.upgradeUISetup();

        base.Awake();
    }

    private void upgradeUISetup()
    {
        this.upgradeIcon = GameObject.Find("UI:SuperShotgun").transform.GetChild(0).GetComponent<Image>();

        this.upgradeSprites = new System.Collections.Generic.Queue<Sprite>();
        for (int i = 1; i < 4; i++)
            this.upgradeSprites.Enqueue(Resources.Load<Sprite>("UpgradeIcon") as Sprite);
        this.upgradeSprites.Enqueue(Resources.Load<Sprite>("FireUpgradeIcon") as Sprite);
        for (int i = 5; i < 10; i++)
            this.upgradeSprites.Enqueue(Resources.Load<Sprite>("UpgradeIcon") as Sprite);
    }

    public override void Fire()
    {
        RaycastHit hitInfo; ;

        List<BasicBulletBehaviour> bullets = new List<BasicBulletBehaviour>();

        for (int i = 0; i < this.PelletCount; i++)
        {
            bullets.Add(bulletPool.Create(Player, 0, MuzzleTrans.position) as ShotgunPelletBehaviour);
        }
        if (Physics.Raycast(Player.transform.position, Player.transform.forward, out hitInfo))
        {
            foreach (BasicBulletBehaviour bul in bullets)
            {
                Quaternion rotation = Quaternion.Euler(Random.Range(-5, 5), Random.Range(-5,5), 0);
                bul.TargetPos = this.MuzzleTrans.position + (rotation*transform.forward);
                bul.Target = hitInfo.collider.gameObject;
            }
        }
        else
        {
            foreach (BasicBulletBehaviour bul in bullets)
            {
                Quaternion rotation = Quaternion.Euler(Random.Range(-5, 5), Random.Range(-5, 5), 0);
                bul.TargetPos = MuzzleTrans.position + this.transform.parent.forward;
                bul.TargetPos = this.MuzzleTrans.position + (rotation * transform.forward);
            }
        }

        if (this.effect != null)
        {
            foreach (BasicBulletBehaviour bul in bullets)
            {
                bul.Effect = this.effect;
                if (this.effect.hasColor)
                    this.effect.SetTargetColor(bul.gameObject);
            }
        }

        foreach (BasicBulletBehaviour bul in bullets)
        {
            bul.Fire();
        }
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
                this.effect = gameObject.AddComponent<FireEffectBehaviour>();
                break;
            default:
                this.fireRate -= 0.05f;
                break;
        }
        base.LevelUp();
    }
}