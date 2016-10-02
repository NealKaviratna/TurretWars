using UnityEngine;
using System.Collections;

/// <summary>
/// Simple Bullet Behaviour for use with Machine Gun and potentially Super Shotgun
/// </summary>
public class BasicBulletBehaviour : BulletBehaviour {
    
    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "Enemy")
        {
            this.basicDamage(coll.gameObject.GetComponent<BaseCreep>());
            this.Die();

            // This feels a bit hacky, but it works and I can't think of a situation where it would break anything.
            GameObject.Find("LocalPlayer").GetComponent<BankBehaviour>().Gold += coll.gameObject.GetComponent<BaseCreep>().Value;
            GameObject go = Instantiate(Resources.Load("+gold")) as GameObject;
            go.transform.position = this.transform.position;
        }
        else if (coll.collider.tag != "Player")
            this.Die();
    }
}
