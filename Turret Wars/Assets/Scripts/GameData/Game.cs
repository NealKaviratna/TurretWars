using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class Game : NetworkBehaviour
{
    public List<Player> Players = new List<Player>();
    public Battlezone battlezone1;
    public Battlezone battlezone2;

    public uint creepIdGen = 0;

    private int playerCount = 0;

    /// <summary>
    /// Setup Game data on client, hook into correct level assets
    /// </summary>a
    public override void OnStartClient()
    {
        base.OnStartClient();
        this.battlezone1 = GameObject.Find("Battlezone").GetComponent<Battlezone>();
        this.battlezone2 = GameObject.Find("Battlezone2").GetComponent<Battlezone>();
        GameObject.Find("Music").GetComponent<AudioSource>().Play();
    }

    /// <summary>
    /// Fetches player by id, allowing player to get passed across network as int
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Player GetPlayerByID(int id)
    {
        return Players[id];
    }

    #region Player Setup
    /// <summary>
    /// Runs of server, informs clients of player connecting
    /// </summary>
    /// <param name="player"></param>
    public void AddPlayer()
    {
        RpcUpdateClients(playerCount++);
    }
    
    /// <summary>
    /// Updates client side game data with correct information
    /// </summary>
    /// <param name="playerCount"></param>
    [ClientRpc]
    public void RpcUpdateClients(int playerCount)
    {
        if (playerCount == 0)
        {
            Debug.LogError("Updating Player 1 Client");
            Player player = GameObject.FindObjectsOfType<Player>()[0].GetComponent<Player>();
            player.gameObject.name = "LocalPlayer";
            player.gameObject.GetComponentInChildren<Camera>().enabled = true;
            player.gameObject.GetComponentInChildren<AudioListener>().enabled = true;
            player.gameObject.transform.position = GameObject.Find("P1Spawn").transform.position;
            player.gameObject.transform.parent = GameObject.Find("Stage").transform;
            player.ID = 0;
            Players.Add(player);
            player.Battlezone = battlezone1;
            player.targetBattlezone = battlezone2;
            GameObject.Find("P1RadarCamera").GetComponent<Camera>().enabled = true;

            GameObject go = GameObject.FindGameObjectsWithTag("CreepController")[0];
            player.CreepController = go.GetComponent<CreepController>();
            go.name = "LocalCreepController";
        }
        else if (playerCount == 1 && Players.Count == 0)
        {

            GameObject.Find("Stage").transform.Rotate(new Vector3(0, 180, 0));
            Player player = GameObject.FindObjectsOfType<Player>()[1].GetComponent<Player>();
            player.gameObject.name = "Player1onP2client";
            player.gameObject.transform.position = GameObject.Find("P1Spawn").transform.position;
            player.ID = 0;
            Players.Add(player);
            player.Battlezone = battlezone1;
            player.targetBattlezone = battlezone2;
            player.bank.start = true;

            GameObject go = GameObject.FindGameObjectsWithTag("CreepController")[0];
            player.CreepController = go.GetComponent<CreepController>();

            Debug.LogError("Updating Player 2 Client");
            player = GameObject.FindObjectsOfType<Player>()[0].GetComponent<Player>();
            player.gameObject.name = "LocalPlayer";
            player.gameObject.transform.position = GameObject.Find("P2Spawn").transform.position;
            player.gameObject.GetComponentInChildren<Camera>().enabled = true;
            player.gameObject.GetComponentInChildren<AudioListener>().enabled = true;
            player.ID = 1;
            Players.Add(player);
            player.Battlezone = battlezone2;
            player.targetBattlezone = battlezone1;
            player.bank.start = true;
            GameObject.Find("P2RadarCamera").GetComponent<Camera>().enabled = true;
            

            go = GameObject.FindGameObjectsWithTag("CreepController")[1];
            player.CreepController = go.GetComponent<CreepController>();
            go.name = "LocalCreepController";
        }
        else
        {
            Debug.LogError("Updating Player 2 on Client 1");
            Player player = GameObject.FindObjectsOfType<Player>()[0].GetComponent<Player>();
            player.gameObject.name = "Player2onP1client";
            player.gameObject.transform.position = GameObject.Find("P2Spawn").transform.position;
            player.ID = 1;
            Players.Add(player);
            player.Battlezone = battlezone2;
            player.targetBattlezone = battlezone1;
            player.bank.start = true;

            GameObject.Find("LocalPlayer").GetComponent<Player>().bank.start = true;

            GameObject go = GameObject.FindGameObjectsWithTag("CreepController")[1];
            player.CreepController = go.GetComponent<CreepController>();
        }
    }
    #endregion
}
