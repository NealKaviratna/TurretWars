using UnityEngine;
using System.Collections;

public class BasicBulletBehaviour : BulletBehaviour {
    
    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "Enemy")
        {
            this.basicDamage(coll.gameObject.GetComponent<SimpleCreep>());
            this.Die();
        }
        else if (coll.collider.tag != "Player")
            this.Die();
    }
}
