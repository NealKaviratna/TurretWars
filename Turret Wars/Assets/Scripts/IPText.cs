using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IPText : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var ipaddress = Network.player.ipAddress;
        this.GetComponent<Text>().text = "My IP: " + ipaddress.ToString();
    }
}
