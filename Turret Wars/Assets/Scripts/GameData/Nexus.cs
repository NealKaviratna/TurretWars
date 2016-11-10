using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// The thing the player is trying to stop creeps from reaching.
/// </summary>
public class Nexus : MonoBehaviour
{

    public int Lives;
    public Player Player;

    // Use this for initialization
    void Start()
    {
        Lives = 25;
    }

    // Update is called once per frame
    void Update()
    {
        // End Game Check
        if (this.Lives <= 0)
        {
            if (Player.isLocalPlayer)
            {
                Debug.Log("You Win");
            }
            else
            {
                Debug.Log("You Win");
            }
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        var creep = coll.gameObject.GetComponent<BaseCreep>();
        if (creep != null)
        {
            if (Player.isLocalPlayer)
            {
                Lives--;
                GameObject.Find("UI:Lives").GetComponent<Text>().text = Lives.ToString();
                Player.CmdSyncLives((uint)Lives);
                creep.Die();
            }
            else
            {
                Lives--;
                GameObject.Find("UI:EnemyLives").GetComponent<Text>().text = Lives.ToString();
            }
        }

        if (Lives <= 0)
        {
            if (Player.isLocalPlayer)
                SceneManager.LoadScene(2,LoadSceneMode.Additive);
            else
                SceneManager.LoadScene(3, LoadSceneMode.Additive);
        }
    }
}
