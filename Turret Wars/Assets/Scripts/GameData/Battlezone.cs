using UnityEngine;
using System.Collections;

/// <summary>
/// Container for information about a given players playing space.
/// </summary>
public class Battlezone : MonoBehaviour {

    public BoxCollider creepSpawner;
    public BoxCollider nexus;

    public BoxCollider CreepSpawner
    {
        get { return creepSpawner; }
    }

    public BoxCollider Nexus
    {
        get { return nexus; }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
