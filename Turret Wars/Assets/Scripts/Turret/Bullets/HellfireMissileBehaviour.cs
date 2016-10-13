using UnityEngine;
using System.Collections;

/// <summary>
/// Simple Bullet Behaviour for use with Machine Gun and potentially Super Shotgun
/// </summary>
public class HellfireMissileBehaviour : BulletBehaviour {

    public void Start()
    {
        this.Recall();
        this.speed = 5.0f;
    }

    void OnCollisionEnter(Collision coll)
    {
        print(coll.collider);
        print(coll.collider.tag);
        if (coll.collider.tag == "Enemy")
        {
            this.basicDamage(coll.gameObject.GetComponent<BaseCreep>());
            this.Die();
        }
        else if (coll.collider.tag != "Player")
        {
            this.Die();
            Debug.Log("hdj");
        }
    }

    public override string ToString()
    {
        return "Missile";
    }
}
