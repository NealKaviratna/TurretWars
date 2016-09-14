using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// The thing the player is trying to stop creeps from reaching.
/// </summary>
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
        var creep = coll.gameObject.GetComponent<BaseCreep>();
        if (creep != null)
        {
            Lives--;
            GameObject.Find("UI:Lives").GetComponent<Text>().text = "Lives: " + Lives.ToString();
            creep.Die();
        }
    }
}
