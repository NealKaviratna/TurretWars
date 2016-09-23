using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour {

	void OnMouseEnter()
    {
        transform.localScale += new Vector3(0.1f, 0, 0);
    }

    void OnMouseExit()
    {
        transform.localScale -= new Vector3(0.1f, 0, 0);
    }

    void OnMouseDown()
    {
        SceneManager.LoadScene("TurretTest");
    }
}
