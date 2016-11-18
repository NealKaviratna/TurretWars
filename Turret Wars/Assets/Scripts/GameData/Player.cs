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
    public BankBehaviour bank;

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
        Debug.LogError("sync attempt");
        this.RpcSyncLives(lives);
    }

    [ClientRpc]
    public void RpcSyncLives(uint lives)
    {
        Debug.LogError("sync successful");
        this.battlezone.Nexus.GetComponent<Nexus>().Lives = (int) lives;
    }

    public void Update()
    {
        if (!isLocalPlayer) return;

        // TODO: make this cleaner
        if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (bank.Gold >= 10 && CreepBank.CreepLeft(1))
            {

                CreepController.SpawnCreep(this.id, CreepNo.Walker1);
                bank.Gold -= 10;
                bank.IncomeAmount += 5;
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (bank.Gold >= 25 && CreepBank.CreepLeft(2))
            {

                CreepController.SpawnCreep(this.id, CreepNo.Walker2);
                bank.Gold -= 25;
                bank.IncomeAmount += 10;
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (bank.Gold >= 50 && CreepBank.CreepLeft(3))
            {

                CreepController.SpawnCreep(this.id, CreepNo.Walker3);
                bank.Gold -= 50;
                bank.IncomeAmount += 25;
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (bank.Gold >= 30 && CreepBank.CreepLeft(4))
            {

                CreepController.SpawnCreep(this.id, CreepNo.Tank1);
                bank.Gold -= 30;
                bank.IncomeAmount += 15;
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (bank.Gold >= 60 && CreepBank.CreepLeft(5))
            {

                CreepController.SpawnCreep(this.id, CreepNo.Tank2);
                bank.Gold -= 60;
                bank.IncomeAmount += 30;
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad6) || Input.GetKeyDown(KeyCode.Alpha6))
        {
            if (bank.Gold >= 90 && CreepBank.CreepLeft(6))
            {

                CreepController.SpawnCreep(this.id, CreepNo.Tank3);
                bank.Gold -= 90;
                bank.IncomeAmount += 45;
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad7) || Input.GetKeyDown(KeyCode.Alpha7))
        {
            if (bank.Gold >= 30 && CreepBank.CreepLeft(7))
            {

                CreepController.SpawnCreep(this.id, CreepNo.Flank1);
                bank.Gold -= 30;
                bank.IncomeAmount += 15;
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.Alpha8))
        {
            if (bank.Gold >= 60 && CreepBank.CreepLeft(8))
            {

                CreepController.SpawnCreep(this.id, CreepNo.Flank2);
                bank.Gold -= 60;
                bank.IncomeAmount += 30;
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad9) || Input.GetKeyDown(KeyCode.Alpha9))
        {
            if (bank.Gold >= 90 && CreepBank.CreepLeft(9))
            {

                CreepController.SpawnCreep(this.id, CreepNo.Flank3);
                bank.Gold -= 90;
                bank.IncomeAmount += 45;
            }
        }
    }
}
