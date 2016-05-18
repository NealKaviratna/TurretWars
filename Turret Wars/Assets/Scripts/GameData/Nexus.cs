using UnityEngine;
using System.Collections;

public class Nexus : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void OnTriggerEnter(Collider coll)
    {
        var creep = coll.gameObject.GetComponent<SimpleCreep>();
        if (creep != null) creep.Die();
    }
}
