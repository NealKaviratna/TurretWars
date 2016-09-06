using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{

    private int id;
    public Battlezone battlezone;
    public Battlezone targetBattlezone;

    public CreepController CreepController;

    public Player(int id)
    {
        this.id = id;
    }

    public int ID
    {
        get { return this.id; }
    }

    public Battlezone Battlezone
    {
        get { return battlezone; }
    }

    public Battlezone TargetBattlezone
    {
        get { return targetBattlezone; }
    }

    public void Start()
    {
        // Register player with Game
        this.id = GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>().addPlayer(this);

        GameObject cf = (GameObject)Instantiate(Resources.Load("CreepFactory"), Vector3.zero, Quaternion.identity);
        NetworkServer.Spawn(cf);
    }

    public void Update()
    {
        if (!isLocalPlayer) return;

        if (Input.GetKeyDown(KeyCode.Keypad7))
            CreepController.CmdSpawnCreep(this.id, CreepNo.SimpleCreep);

    }
}
