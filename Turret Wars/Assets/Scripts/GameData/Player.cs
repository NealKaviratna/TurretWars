using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

/// <summary>
/// Player class. Contains player data as well as creep summoning input handling.
/// </summary>
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

        // TODO: make this cleaner
        if (Input.GetKeyDown(KeyCode.Keypad7) || Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (GetComponent<BankBehaviour>().Gold >= 50)
            {

                CreepController.SpawnCreep(this.id, CreepNo.Walker1);
                GetComponent<BankBehaviour>().Gold -= 50;
                GetComponent<BankBehaviour>().IncomeAmount += 25;
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (GetComponent<BankBehaviour>().Gold >= 100)
            {

                CreepController.SpawnCreep(this.id, CreepNo.Walker2);
                GetComponent<BankBehaviour>().Gold -= 100;
                GetComponent<BankBehaviour>().IncomeAmount += 50;
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (GetComponent<BankBehaviour>().Gold >= 150)
            {

                CreepController.SpawnCreep(this.id, CreepNo.Walker3);
                GetComponent<BankBehaviour>().Gold -= 150;
                GetComponent<BankBehaviour>().IncomeAmount += 50;
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (GetComponent<BankBehaviour>().Gold >= 80)
            {

                CreepController.SpawnCreep(this.id, CreepNo.Tank1);
                GetComponent<BankBehaviour>().Gold -= 80;
                GetComponent<BankBehaviour>().IncomeAmount += 40;
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (GetComponent<BankBehaviour>().Gold >= 160)
            {

                CreepController.SpawnCreep(this.id, CreepNo.Tank2);
                GetComponent<BankBehaviour>().Gold -= 160;
                GetComponent<BankBehaviour>().IncomeAmount += 80;
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha6))
        {
            if (GetComponent<BankBehaviour>().Gold >= 240)
            {

                CreepController.SpawnCreep(this.id, CreepNo.Tank3);
                GetComponent<BankBehaviour>().Gold -= 240;
                GetComponent<BankBehaviour>().IncomeAmount += 120;
            }
        }
    }
}
