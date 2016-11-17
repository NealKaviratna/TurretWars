using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Networking;

public class HellfireMissileLauncher : Weapon
{

    public Player Player;
    public Transform MuzzleTrans;
    public int MissileCount;

    private ObjectPool<HellfireMissileBehaviour> missilePool;

    private float timer;

    private Image reticle;

    // Use this for initialization
    protected override void Awake()
    {
        this.level = 0;
        this.fireRate = 3.0f;
        this.timer = this.fireRate;

        var DummyGameObject = Instantiate(Resources.Load("dgo")) as GameObject;
        missilePool = new ObjectPool<HellfireMissileBehaviour>(DummyGameObject);

        this.upgradeUISetup();
        this.reticle = GameObject.Find("UI:Crosshair").GetComponent<Image>();

        base.Awake();
    }

    private void upgradeUISetup()
    {
        this.upgradeIcon = GameObject.Find("UI:HellfireMissileLauncher").transform.GetChild(0).GetComponent<Image>();
        this.upgradeSprites = new System.Collections.Generic.Queue<Sprite>();
        for (int i = 1; i < 4; i++)
            this.upgradeSprites.Enqueue(Resources.Load<Sprite>("UpgradeIcon") as Sprite);
        this.upgradeSprites.Enqueue(Resources.Load<Sprite>("LightningUpgradeIcon") as Sprite);
        for (int i = 5; i < 10; i++)
            this.upgradeSprites.Enqueue(Resources.Load<Sprite>("UpgradeIcon") as Sprite);
    }

    public override void Fire()
    {
        RaycastHit hitInfo;

        List<HellfireMissileBehaviour> missiles = new List<HellfireMissileBehaviour>();

        for (int i = 0; i < this.MissileCount; i++)
        {
            missiles.Add(missilePool.Create(Player, 0, MuzzleTrans.position) as HellfireMissileBehaviour);
        }
        if (Physics.Raycast(Player.transform.position, Player.transform.forward, out hitInfo)
            && hitInfo.collider.tag == "Enemy")
        {
            foreach (HellfireMissileBehaviour missile in missiles)
            {
                Quaternion rotation = Quaternion.Euler(Random.Range(-30, -60), Random.Range(-15, 15), 0);

                Vector3 vecToTarget = hitInfo.collider.transform.position - this.transform.position;
                missile.TargetPos = this.MuzzleTrans.position + (rotation * vecToTarget);
                missile.Target = hitInfo.collider.gameObject;
            }
        }
        else
        {
            foreach (HellfireMissileBehaviour missile in missiles)
                missile.Die();
            return;
        }

        if (this.effect != null)
        {
            foreach (HellfireMissileBehaviour missile in missiles)
            {
                missile.Effect = this.effect;
                if (this.effect.hasColor)
                    this.effect.SetTargetColor(missile.gameObject);
            }
        }

        foreach (HellfireMissileBehaviour missile in missiles)
        {
            missile.Fire();
        }
        base.Fire();
    }

    protected override void Update()
    {
        if (!gameObject.transform.parent.gameObject.GetComponent<NetworkIdentity>().isLocalPlayer) return;


        this.timer += Time.deltaTime;
        reticle.color = Color.white;
        if (this.timer >= this.fireRate)
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(Player.transform.position, Player.transform.forward, out hitInfo)
            && hitInfo.collider.tag == "Enemy")
                reticle.color = Color.red;

            if (Input.GetKey(KeyCode.Mouse0))
            {
                Fire();
                this.timer = 0.0f;
            }
        }
        base.Update();
    }

    public override void LevelUp()
    {
        switch (this.level++)
        {
            case 4:
                this.effect = gameObject.AddComponent<LightningEffectBehaviour>();
                break;
            default:
                this.fireRate -= 0.1f;
                break;
        }
        base.LevelUp();
    }
}
