using UnityEngine;
using System.Collections;

public class BasicBulletBehaviour : BulletBehaviour {
    
    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "enemy")
            this.basicDamage();
    }
}
