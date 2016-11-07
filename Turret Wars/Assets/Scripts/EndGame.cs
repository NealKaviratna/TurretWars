using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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
            SceneManager.LoadScene(0);
        }
    }
}
