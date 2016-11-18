using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{

    public MovieTexture Tutorial;
    public GameObject TutorialScene;

    // Use this for initialization
    void Start()
    {
        SceneManager.LoadSceneAsync("TurretTest", LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject netNav = GameObject.Find("NetworkManager");
        if (!Tutorial.isPlaying && netNav != null)
        {
            netNav.GetComponent<MyNetworkManager>().JoinGame();
            GameObject.Destroy(TutorialScene);
        }
    }
}
