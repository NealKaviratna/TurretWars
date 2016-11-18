using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class EndGame : MonoBehaviour
{

    private float timer;

    // Use this for initialization
    void Start()
    {
        timer = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0.0f && Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject nm = GameObject.Find("NetworkManager");
            if (nm != null)
                nm.GetComponent<MyNetworkManager>().LeaveGame();

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(0);
        }
    }
}
