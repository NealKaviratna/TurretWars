using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private int id;
    public Battlezone battlezone;
    public Battlezone targetBattlezone;

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
}
