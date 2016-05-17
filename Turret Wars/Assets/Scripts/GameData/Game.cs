using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Will only be on server
public class Game : MonoBehaviour {
    // Will be replaced by RPC calls
    public CreepFactory CreepFactory;

    public List<Player> Players = new List<Player>();

	// Use this for initialization
	void Start () {
        CreepFactory = new CreepFactory();
	}
}
