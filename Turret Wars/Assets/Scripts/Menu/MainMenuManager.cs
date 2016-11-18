using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{

    public GameObject NetworkUI;

    public void PlayGame()
    {
        SceneManager.LoadScene("TurretTest");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StoreHostIP()
    {
        GameObject.Find("hostIP").GetComponent<Text>().text = GameObject.Find("UI:HostIP").GetComponent<InputField>().text;
        GameObject.DontDestroyOnLoad(GameObject.Find("hostIP"));
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.B) && Input.GetKey(KeyCode.A))
        {
            NetworkUI.SetActive(true);
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.N))
        {
            NetworkUI.SetActive(false);
        }
    }
}
