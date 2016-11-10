using UnityEngine;
using System.Collections;

/// <summary>
/// Simple Bullet Behaviour for use with Machine Gun and potentially Super Shotgun
/// </summary>
public class MenuBulletBehaviour : BulletBehaviour
{
    public float Speed
    {
        get { return this.speed; }
        set { this.speed = value; }
    }

    public override Poolable Create(Player player, uint id, Vector3 pos)
    {
        base.Create(player, id, pos);
        this.timer = 30.0f;
        return this;
    }

    public override string ToString()
    {
        return "MenuBullet";
    }

    void OnCollisionEnter(Collision coll)
    {
        if (this.timer < 29.95f)
            this.Die();
    }
}
