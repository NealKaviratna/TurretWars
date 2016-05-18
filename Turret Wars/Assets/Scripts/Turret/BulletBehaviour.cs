using UnityEngine;
using System.Collections;

public abstract class BulletBehaviour : MonoBehaviour {

    public GameObject Target;
    public TrailRenderer TrailRenderer;

    protected bool isHoming;

    protected void playSound()
    {

    }

    protected void playParticles()
    {

    }

    protected void basicDamage(float DamageTimer = 0.0f)
    {

    }

    protected void aoeDamage(float DamageBoxDuration = 0.0f, float DamageTimer = 0.0f)
    {

    }

    public abstract void Fire();

    // Use this for initialization
    void Start () {
        if (TrailRenderer != null) TrailRenderer.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
