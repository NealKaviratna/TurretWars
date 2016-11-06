using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// Used with original main menu, deprecated.
/// </summary>
public class NewGame : MonoBehaviour {

	public void OnMouseEnter()
    {
        transform.localScale += new Vector3(0.1f, 0, 0);
    }

    public void OnMouseExit()
    {
        transform.localScale -= new Vector3(0.1f, 0, 0);
    }

    public void OnMouseDown()
    {
        SceneManager.LoadScene("TurretTest");
    }
}
