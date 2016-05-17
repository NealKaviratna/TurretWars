using UnityEngine;
using System.Collections;

public class DebugButtons : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.U))
        {
            Debug.Log("test");
        }
	}
}
