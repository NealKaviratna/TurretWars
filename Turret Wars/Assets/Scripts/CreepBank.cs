using UnityEngine;
using System.Collections;

public class CreepBank : MonoBehaviour {

    public CreepUI[] CreepUI;

	// Use this for initialization
	void Start () {
        CreepUI = GameObject.Find("UI:CreepSelect").transform.GetComponentsInChildren<CreepUI>();
	}

    public bool CreepLeft(int creepNo)
    {
        return CreepUI[creepNo - 1].HasCreep;
    }
}
