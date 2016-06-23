using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class CreepController : MonoBehaviour {

    public CreepNo creepNo;
    public Player player;

    private uint creepIdGen;
    
    //[Command]
    public void CmdSpawnAssociatedCreep()
    {
        //TODO: Generate creepID
        //TODO: Call appropriate creep factory method across all clients (RPC)
        GameObject.Find("CreepFactory").GetComponent<CreepFactory>().CreateCreep(this.creepNo, player, creepIdGen++);
    }

    //[Command]
    public void CmdRecallCreep(uint creepID)
    {
        GameObject.Find("CreepFactory").GetComponent<CreepFactory>().RecallCreep(creepID);
    }

    // Use this for initialization
    void Start () {
        creepIdGen = 0;
	}
	
	// Update is called once per frame
	void Update () {
	    if (creepIdGen < 10)
        {
            CmdSpawnAssociatedCreep();
        }
	}
}
