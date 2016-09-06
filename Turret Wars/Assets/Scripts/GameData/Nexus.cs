using UnityEngine;
using System.Collections;

public class Nexus : MonoBehaviour
{

    public int Lives;

    // Use this for initialization
    void Start()
    {
        Lives = 25;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider coll)
    {
        var creep = coll.gameObject.GetComponent<SimpleCreep>();
        if (creep != null)
        {
            Lives--;
            creep.Die();
        }
    }
}
