using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MyNetworkManager : NetworkManager
{

    public override void OnStartClient(NetworkClient client)
    {
        GameObject.Find("UI:MyNetNav").SetActive(false);
        base.OnStartClient(client);
    }

    public void JoinGameButton()
    {
        string HostAddress = GameObject.Find("UI:HostIP").GetComponent<InputField>().text;
        base.networkAddress = HostAddress;
        base.StartClient();
    }
}
