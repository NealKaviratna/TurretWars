using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

	public void PlayGame()
    {
        SceneManager.LoadScene("TurretTest");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
