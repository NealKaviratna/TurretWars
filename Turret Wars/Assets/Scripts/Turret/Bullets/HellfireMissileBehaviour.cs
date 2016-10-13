using UnityEngine;
using System.Collections;

/// <summary>
/// Simple Bullet Behaviour for use with Machine Gun and potentially Super Shotgun
/// </summary>
public class HellfireMissileBehaviour : BulletBehaviour {

    public void Start()
    {
        this.Recall();
        this.speed = 50.0f;
        this.isHoming = true;
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "Enemy")
        {
            this.basicDamage(coll.gameObject.GetComponent<BaseCreep>());
            this.Die();
        }
        else if (coll.collider.tag != "Player")
        {
            this.Die();
        }
    }

    public override string ToString()
    {
        return "Missile";
    }
}
