using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// SandBox class for bullets. All bullets should inherit from this.
/// Use protected methods to create desired behaviour.
/// </summary>
public abstract class BulletBehaviour : Poolable
{

    public GameObject Target;
    public Vector3 TargetPos;
    public TrailRenderer TrailRenderer;
    public EffectBehaviour Effect;
    public AudioClip HitSFX;

    protected float speed = 100.0f;
    protected bool isHoming = false;
    protected float turnSpeed = 0.1f;
    protected bool inUse = false;

    protected float timer = 0.0f;

    #region Bullet Sandbox
    protected float damageAmount = 10.0f;

    private event EventHandler hit;

    protected void aoeDamage(float DamageBoxDuration = 0.0f, float DamageTimer = 0.0f)
    {

    }

    protected void basicDamage(BaseCreep target, float DamageTimer = 0.0f)
    {
        target.Hp -= this.damageAmount;

        if (this.Effect != null)
            this.AddEffect(target.gameObject);

        if (hit != null)
            hit(this, EventArgs.Empty);
    }

    private void AddEffect(GameObject target)
    {
        switch (Effect.ToString())
        {
            case "FrostEffectBehaviour":
                target.AddComponent<FrostEffectBehaviour>();
                break;
            case "FireEffectBehaviour":
                target.AddComponent<FireEffectBehaviour>();
                break;
            default:
                break;
        }
    }

    public virtual void Fire()
    {
        if (TrailRenderer != null) TrailRenderer.enabled = true;
        if (TargetPos != null) transform.LookAt(TargetPos);
        GetComponent<Rigidbody>().velocity = speed * transform.forward;
    }
    #endregion

    #region MonoBehaviour
    // Use this for initialization
    protected virtual void Start()
    {
        this.HitSFX = Resources.Load("LaserHitSFX") as AudioClip;
        var gf = GameObject.Find("GameFeel");
        if (gf != null)
            hit += gf.GetComponent<SoundPlayer>().ShotHitHandler;
        this.GetComponent<Rigidbody>().freezeRotation = true;
        this.Recall();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if((this.timer -= Time.deltaTime) <= 0.0f)
        {
            this.Die();
        }
        if (this.isHoming)
        {
            if (Target != null)
            {
                Vector3 direction = Target.transform.position - transform.position;
                Quaternion targetRotation = Quaternion.FromToRotation(transform.forward, direction);

                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed);
            }
            GetComponent<Rigidbody>().velocity = speed * transform.forward;
        }
        if (GetComponent<Rigidbody>().velocity.magnitude < 0.0f)
            this.Die();
    }
    #endregion

    #region Poolable Overrides
    public override uint ObjectId
    {
        get { return 0; }
    }


    public override bool InUse
    {
        get { return inUse; }
    }

    public override Poolable Create(Player player, uint id, Vector3 pos)
    {
        this.transform.position = pos;
        this.inUse = true;
        this.gameObject.SetActive(true);
        this.timer = 2.0f;
        return this;
    }

    public override void Die()
    {
        TrailRenderer tr = GetComponentInChildren<TrailRenderer>();
        if (tr != null)
            tr.Clear();

        this.inUse = false;
        this.gameObject.SetActive(false);
    }

    public override void Recall()
    {
        this.inUse = false;
        this.gameObject.SetActive(false);
    }

    public override string ToString()
    {
        return "Bullet";
    }
    #endregion
}
