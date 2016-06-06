using UnityEngine;
using System.Collections;

public abstract class BulletBehaviour : Poolable {

    public GameObject Target;
    public Vector3 TargetPos;
    public TrailRenderer TrailRenderer;

    protected float speed;
    protected bool isHoming;
    protected bool inUse;

    protected void aoeDamage(float DamageBoxDuration = 0.0f, float DamageTimer = 0.0f)
    {

    }

    protected void basicDamage(float DamageTimer = 0.0f)
    {

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
        GetComponent<Rigidbody>().AddForce(Vector3.forward);
    }

    // Use this for initialization
    void Start () {
        this.Fire();
    }
	
	// Update is called once per frame
	void Update () {
	    if (this.isHoming)
            if (Target != null) transform.LookAt(Target.transform.position);
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
        return this;
    }

    public override void Die()
    {

    }

    public override void Recall()
    {

    }

    public override string ToString()
    {
        return "BulletBehaviour";
    }
}
