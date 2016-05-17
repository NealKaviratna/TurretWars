using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    
    private int id;
    public Battlezone battlezone;
    public Battlezone targetBattlezone;

    public Battlezone Battlezone
    {
        get { return battlezone; }
    }

    public Battlezone TargetBattlezone
    {
        get { return targetBattlezone; }
    }
}
