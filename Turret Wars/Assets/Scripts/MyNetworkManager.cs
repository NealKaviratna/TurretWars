using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MyNetworkManager : NetworkManager
{
    public void Start()
    {
        GetComponent<MyNetworkManager>().JoinGame();
    }

    public override void OnStartClient(NetworkClient client)
    {
        base.OnStartClient(client);
    }

    public void JoinGame()
    {
        GameObject ip = GameObject.Find("hostIP");
        if (ip != null)
        {
            string HostAddress = ip.GetComponent<Text>().text;
            base.networkAddress = HostAddress;
            base.StartClient();
        }
        else
        {
            base.StartHost();
        }
    }

    public void LeaveGame()
    {
        Shutdown();
    }
}
