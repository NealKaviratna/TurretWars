using UnityEngine;
using System.Collections;

/// <summary>
/// Simple Bullet Behaviour for use with Machine Gun and potentially Super Shotgun
/// </summary>
public class HellfireMissileBehaviour : BulletBehaviour
{

    protected override void Start()
    {
        this.speed = 1.0f;
        this.isHoming = true;
        base.Start();
    }

    protected override void Update()
    {
        if (this.speed < 50.0f)
        {
            this.speed *= 1.06f;
            this.turnSpeed = this.speed * 0.002f;
        }
        base.Update();
    }

    public override Poolable Create(Player player, uint id, Vector3 pos)
    {
        this.speed = 1.0f;
        return base.Create(player, id, pos);
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
