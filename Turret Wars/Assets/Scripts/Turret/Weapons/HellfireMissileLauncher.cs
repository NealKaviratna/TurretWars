using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class HellfireMissileLauncher : Weapon
{

    public Player Player;
    public Transform MuzzleTrans;
    public int MissileCount;

    private ObjectPool<HellfireMissileBehaviour> missilePool;

    private EffectBehaviour effect;

    private float timer;

    // Use this for initialization
    void Start()
    {
        this.level = 0;
        this.fireRate = 3.0f;
        this.timer = this.fireRate;
        var DummyGameObject = Instantiate(Resources.Load("dgo")) as GameObject;
        missilePool = new ObjectPool<HellfireMissileBehaviour>(DummyGameObject);
    }
    
    public override void Fire()
    {
        RaycastHit hitInfo; ;

        List<HellfireMissileBehaviour> missiles = new List<HellfireMissileBehaviour>();

        for (int i = 0; i < this.MissileCount; i++)
        {
            missiles.Add(missilePool.Create(Player, 0, MuzzleTrans.position) as HellfireMissileBehaviour);
        }
        if (Physics.Raycast(Player.transform.position, Player.transform.forward, out hitInfo))
        {
            foreach (HellfireMissileBehaviour missile in missiles)
            {
                Quaternion rotation = Quaternion.Euler(Random.Range(-30, -60), Random.Range(-15, 15), 0);
                missile.TargetPos = this.MuzzleTrans.position + (rotation * Player.transform.forward);
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
