using UnityEngine;
using System.Collections;

public class BasicBulletBehaviour : BulletBehaviour {
    
    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "Enemy")
        {
            this.basicDamage(coll.gameObject.GetComponent<SimpleCreep>());
            this.Die();

            GameObject.Find("LocalPlayer").GetComponent<BankBehaviour>().Gold += coll.gameObject.GetComponent<SimpleCreep>().value;
            GameObject go = Instantiate(Resources.Load("+gold")) as GameObject;
            go.transform.position = this.transform.position;
        }
        else if (coll.collider.tag != "Player")
            this.Die();
    }
}
