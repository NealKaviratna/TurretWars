using UnityEngine;
using System.Collections;

/// <summary>
/// Simple Bullet Behaviour for use with Machine Gun and potentially Super Shotgun
/// </summary>
public class MenuBulletBehaviour : BulletBehaviour
{
    public override Poolable Create(Player player, uint id, Vector3 pos)
    {
        base.Create(player, id, pos);
        this.timer = 10.0f;
        return this;
    }

    public override string ToString()
    {
        return "MenuBullet";
    }

    void OnCollisionEnter(Collision coll)
    {
        if (this.timer < 9.95f)
            this.Die();
    }
}
