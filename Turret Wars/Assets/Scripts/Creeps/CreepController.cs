using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

// Exists on server
public class CreepController : NetworkBehaviour
{

    private uint creepIdGen;
    private GameObject[] creepFactories;

    [Command]
    public void CmdSpawnCreep(int playerID, CreepNo creepNo)
    {
        foreach(GameObject cf in creepFactories)
            cf.GetComponent<CreepFactory>().RpcCreateCreep(creepNo, playerID, creepIdGen++);
    }

    [Command]
    public void CmdRecallCreep(uint creepID)
    {
        foreach(GameObject cf in creepFactories)
            cf.GetComponent<CreepFactory>().RpcRecallCreep(creepID);
    }

    // Use this for initialization
    public void GameStart()
    {
        creepIdGen = 0;
        creepFactories = GameObject.FindGameObjectsWithTag("CreepFactory");
    }
}
