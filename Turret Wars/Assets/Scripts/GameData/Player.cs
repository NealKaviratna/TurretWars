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

    public CreepBank CreepBank;

    public int ID
    {
        get { return this.id; }
        set { this.id = value; }
    }

    public Battlezone Battlezone
    {
        get { return battlezone; }
        set
        {
            this.battlezone = value;
            this.battlezone.Nexus.GetComponent<Nexus>().Player = this;
        }
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



    [Command]
    public void CmdSyncLives(uint lives)
    {
        this.RpcSyncLives(lives);
    }

    [ClientRpc]
    public void RpcSyncLives(uint lives)
    {
        this.battlezone.Nexus.GetComponent<Nexus>().Lives = (int) lives;
    }

    public void Update()
    {
        if (!isLocalPlayer) return;

        // TODO: make this cleaner
        if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (GetComponent<BankBehaviour>().Gold >= 50 && CreepBank.CreepLeft(1))
            {

                CreepController.SpawnCreep(this.id, CreepNo.Walker1);
                GetComponent<BankBehaviour>().Gold -= 50;
                GetComponent<BankBehaviour>().IncomeAmount += 25;
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (GetComponent<BankBehaviour>().Gold >= 100 && CreepBank.CreepLeft(2))
            {

                CreepController.SpawnCreep(this.id, CreepNo.Walker2);
                GetComponent<BankBehaviour>().Gold -= 100;
                GetComponent<BankBehaviour>().IncomeAmount += 50;
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (GetComponent<BankBehaviour>().Gold >= 150 && CreepBank.CreepLeft(3))
            {

                CreepController.SpawnCreep(this.id, CreepNo.Walker3);
                GetComponent<BankBehaviour>().Gold -= 150;
                GetComponent<BankBehaviour>().IncomeAmount += 50;
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (GetComponent<BankBehaviour>().Gold >= 80 && CreepBank.CreepLeft(4))
            {

                CreepController.SpawnCreep(this.id, CreepNo.Tank1);
                GetComponent<BankBehaviour>().Gold -= 80;
                GetComponent<BankBehaviour>().IncomeAmount += 40;
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (GetComponent<BankBehaviour>().Gold >= 160 && CreepBank.CreepLeft(5))
            {

                CreepController.SpawnCreep(this.id, CreepNo.Tank2);
                GetComponent<BankBehaviour>().Gold -= 160;
                GetComponent<BankBehaviour>().IncomeAmount += 80;
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad6) || Input.GetKeyDown(KeyCode.Alpha6))
        {
            if (GetComponent<BankBehaviour>().Gold >= 240 && CreepBank.CreepLeft(6))
            {

                CreepController.SpawnCreep(this.id, CreepNo.Tank3);
                GetComponent<BankBehaviour>().Gold -= 240;
                GetComponent<BankBehaviour>().IncomeAmount += 120;
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad7) || Input.GetKeyDown(KeyCode.Alpha7))
        {
            if (GetComponent<BankBehaviour>().Gold >= 80 && CreepBank.CreepLeft(7))
            {

                CreepController.SpawnCreep(this.id, CreepNo.Flank1);
                GetComponent<BankBehaviour>().Gold += 80;
                GetComponent<BankBehaviour>().IncomeAmount += 40;
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.Alpha8))
        {
            if (GetComponent<BankBehaviour>().Gold >= 160 && CreepBank.CreepLeft(8))
            {

                CreepController.SpawnCreep(this.id, CreepNo.Flank2);
                GetComponent<BankBehaviour>().Gold -= 160;
                GetComponent<BankBehaviour>().IncomeAmount += 80;
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad9) || Input.GetKeyDown(KeyCode.Alpha9))
        {
            if (GetComponent<BankBehaviour>().Gold >= 240 && CreepBank.CreepLeft(9))
            {

                CreepController.SpawnCreep(this.id, CreepNo.Flank3);
                GetComponent<BankBehaviour>().Gold -= 240;
                GetComponent<BankBehaviour>().IncomeAmount += 120;
            }
        }
    }
}
