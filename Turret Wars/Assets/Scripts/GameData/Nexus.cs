using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
            GameObject.Find("UI:Lives").GetComponent<Text>().text = "Lives: " + Lives.ToString();
            creep.Die();
        }
    }
}
