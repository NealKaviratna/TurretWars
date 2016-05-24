using UnityEngine;
using System.Collections;

public abstract class BulletBehaviour : MonoBehaviour {

    public GameObject Target;
    public Vector3 TargetPos;
    public TrailRenderer TrailRenderer;

    protected bool isHoming;

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
}
