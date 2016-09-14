using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Networking code for Creep system
/// </summary>
public class CreepController : NetworkBehaviour
{

    [SerializeField]
    private CreepFactory creepFactory;

    private Game game;

    public void SpawnCreep(int playerID, CreepNo creepNo)
    {
        this.CmdSpawnCreep(playerID, creepNo);
    }

    [Command]
    public void CmdSpawnCreep(int playerID, CreepNo creepNo)
    {
        this.RpcSpawnCreep(creepNo, playerID, game.creepIdGen++);
    }

    [ClientRpc]
    public void RpcSpawnCreep(CreepNo creepNo, int playerID, uint creepId)
    {
        creepFactory.CreateCreep(creepNo, playerID, creepId);
    }

    public void RecallCreep(uint creepId)
    {
        this.CmdRecallCreep(creepId);
    }

    [Command]
    public void CmdRecallCreep(uint creepId)
    {
        this.RpcRecallCreep(creepId);
    }

    [ClientRpc]
    public void RpcRecallCreep(uint creepId)
    {
        creepFactory.RecallCreep(creepId);
    }

    public override void OnStartServer()
    {
        this.game = GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>();
    }

    public override void OnStartClient()
    {
        this.creepFactory = GameObject.FindGameObjectWithTag("CreepFactory").GetComponent<CreepFactory>();
    }
}
