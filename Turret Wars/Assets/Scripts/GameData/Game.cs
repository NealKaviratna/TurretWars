using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {
    public CreepFactory CreepFactory;

    public List<Player> Players = new List<Player>();

    public Player GetPlayerByID(int id)
    {
        return Players[id];
    }

	// Use this for initialization
	void Start () {
        CreepFactory = new CreepFactory();

        Players.Add(new Player(0));
        Players.Add(new Player(1));
	}
}
