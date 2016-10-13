using UnityEngine;
using System.Collections;

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

    protected float speed = 100.0f;
    protected bool isHoming = false;
    protected bool inUse = false;

    protected float damageAmount = 10.0f;

    protected void aoeDamage(float DamageBoxDuration = 0.0f, float DamageTimer = 0.0f)
    {

    }

    protected void basicDamage(BaseCreep target, float DamageTimer = 0.0f)
    {
        target.Hp -= this.damageAmount;


        // This feels a bit hacky, but it works and I can't think of a situation where it would break anything.
        if (this.Effect != null)
            this.AddEffect(target.gameObject);
    }

    private void AddEffect(GameObject target)
    {
        switch (Effect.ToString())
        {
            case "FrostEffectBehaviour":
                target.AddComponent<FrostEffectBehaviour>();
                break;
            default:
                break;
        }
    }

    private void playParticles()
    {

    }

    protected void playSound()
    {

    }

    public virtual void Fire()
    {
        if (TrailRenderer != null) TrailRenderer.enabled = true;
        if (TargetPos != null) transform.LookAt(TargetPos);
        GetComponent<Rigidbody>().velocity = speed * transform.forward;
    }

    // Use this for initialization
    void Start()
    {
        this.Recall();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isHoming)
            if (Target != null) transform.LookAt(Target.transform.position);
        if (GetComponent<Rigidbody>().velocity.magnitude < 5.0f)
            this.Die();
    }

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
}
