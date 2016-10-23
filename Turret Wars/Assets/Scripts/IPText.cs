using UnityEngine;
using System.Collections;

public class IPText : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var ipaddress = Network.player.ipAddress;
        GameObject.Find("IP").GetComponent<TextMesh>().text = "IP: " + ipaddress.ToString();
    }
}
