using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{

    [SerializeField]
    private int id;
    public Battlezone battlezone;
    public Battlezone targetBattlezone;

    public CreepController CreepController;

    public GameObject CFactory;
    public GameObject CController;
    public GameObject GamePrefab;

    public int ID
    {
        get { return this.id; }
        set { this.id = value; }
    }

    public Battlezone Battlezone
    {
        get { return battlezone; }
    }

    public Battlezone TargetBattlezone
    {
        get { return targetBattlezone; }
    }

    public override void OnStartLocalPlayer()
    {
        this.CmdSetup();
        // Hack because can't pass back ints from commands without unnecessarily complicated stuff
        // this.id = GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>().Players.Count - 1;
    }

    [Command]
    public void CmdSetup()
    {
        GameObject gp = (GameObject)Instantiate(GamePrefab, Vector3.zero, Quaternion.identity);
        NetworkServer.Spawn(gp);

        GameObject cf = (GameObject)Instantiate(CFactory, Vector3.zero, Quaternion.identity);
        NetworkServer.SpawnWithClientAuthority(cf, connectionToClient);

        GameObject ccon = (GameObject)Instantiate(CController, Vector3.zero, Quaternion.identity);
        NetworkServer.SpawnWithClientAuthority(ccon, connectionToClient);

        // Register player with Game
        GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>().AddPlayer();
    }

    public void Update()
    {
        if (!isLocalPlayer) return;

        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            if (GetComponent<BankBehaviour>().Gold >= 50)
            {

                CreepController.SpawnCreep(this.id, CreepNo.SimpleCreep);
                GetComponent<BankBehaviour>().Gold -= 50;
                GetComponent<BankBehaviour>().IncomeAmount += 25;
            }
        }
    }
}
