using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class CreepController : NetworkBehaviour {

    public CreepNo creepNo;
    public Player player;

    private uint creepIdGen;
    
    [Command]
    public void CmdSpawnAssociatedCreep()
    {
        //TODO: Generate creepID
        GameObject.Find("CreepFactory").GetComponent<CreepFactory>().RpcCreateCreep(this.creepNo, player.ID, creepIdGen++);
    }

    [Command]
    public void CmdRecallCreep(uint creepID)
    {
        GameObject.Find("CreepFactory").GetComponent<CreepFactory>().RpcRecallCreep(creepID);
    }

    // Use this for initialization
    void Start () {
        creepIdGen = 0;
	}
}
