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

    public override void OnStartClient()
    {
        base.OnStartClient();
        this.battlezone1 = GameObject.Find("Battlezone").GetComponent<Battlezone>();
        this.battlezone2 = GameObject.Find("Battlezone2").GetComponent<Battlezone>();
    }

    public Player GetPlayerByID(int id)
    {
        Debug.Log(id);
        return Players[id];
    }

    public void AddPlayer(Player player)
    {
        Players.Add(player);

        if (Players.Count == 1)
        {
            player.battlezone = battlezone1;
            player.targetBattlezone = battlezone2;

            GameObject go = GameObject.FindGameObjectsWithTag("CreepController")[0];
            player.CreepController = go.GetComponent<CreepController>();
        }
        else
        {
            player.battlezone = battlezone2;
            player.targetBattlezone = battlezone1;

            GameObject go = GameObject.FindGameObjectsWithTag("CreepController")[1];
            player.CreepController = go.GetComponent<CreepController>();
        }
        
        RpcUpdateClients(Players.Count);
    }

    [ClientRpc]
    public void RpcUpdateClients(int playerCount)
    {
        if (playerCount == 1)
        {
            Debug.LogError("Updating Player 1 Client");
            Player player = GameObject.FindObjectsOfType<Player>()[0].GetComponent<Player>();
            player.gameObject.name = "Player 1";
            player.ID = 0;
            Players.Add(player);
            player.battlezone = battlezone1;
            player.targetBattlezone = battlezone2;

            GameObject go = GameObject.FindGameObjectsWithTag("CreepController")[0];
            player.CreepController = go.GetComponent<CreepController>();
        }
        else if (playerCount == 2 || Players.Count == 0)
        {

            Player player = GameObject.FindObjectsOfType<Player>()[1].GetComponent<Player>();
            player.gameObject.name = "Player1onP2client";
            player.ID = 0;
            Players.Add(player);
            player.battlezone = battlezone1;
            player.targetBattlezone = battlezone2;

            GameObject go = GameObject.FindGameObjectsWithTag("CreepController")[0];
            player.CreepController = go.GetComponent<CreepController>();

            Debug.LogError("Updating Player 2 Client");
            player = GameObject.FindObjectsOfType<Player>()[0].GetComponent<Player>();
            player.gameObject.name = "Player 2";
            player.ID = 1;
            Players.Add(player);
            player.battlezone = battlezone2;
            player.targetBattlezone = battlezone1;

            go = GameObject.FindGameObjectsWithTag("CreepController")[1];
            player.CreepController = go.GetComponent<CreepController>();
        }
        else
        {
            Debug.LogError("Updating Player 2 on Client 1");
            Player player = GameObject.FindObjectsOfType<Player>()[0].GetComponent<Player>();
            player.gameObject.name = "Player2onP1client";
            player.ID = 1;
            Players.Add(player);
            player.battlezone = battlezone2;
            player.targetBattlezone = battlezone1;

            GameObject go = GameObject.FindGameObjectsWithTag("CreepController")[1];
            player.CreepController = go.GetComponent<CreepController>();
        }
    }
}
