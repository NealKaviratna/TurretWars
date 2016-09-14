using UnityEngine;
using System.Collections;

/// <summary>
/// SandBox class for bullets. All bullets should inherit from this.
/// Use protected methods to create desired behaviour.
/// </summary>
public abstract class BulletBehaviour : Poolable {

    public GameObject Target;
    public Vector3 TargetPos;
    public TrailRenderer TrailRenderer;

    protected float speed = 100.0f;
    protected bool isHoming = false;
    protected bool inUse = false;

    protected void aoeDamage(float DamageBoxDuration = 0.0f, float DamageTimer = 0.0f)
    {

    }

    protected void basicDamage(BaseCreep target, float DamageTimer = 0.0f)
    {
        target.Die();
    }

    private void playParticles()
    {

    }

    protected void playSound()
    {

    }

    public virtual void Fire() {
        if (TrailRenderer != null) TrailRenderer.enabled = true;
        if (TargetPos != null) transform.LookAt(TargetPos);
        GetComponent<Rigidbody>().velocity = speed * transform.forward;
    }

    // Use this for initialization
    void Start () {
        this.Recall();
    }
	
	// Update is called once per frame
	void Update () {
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
