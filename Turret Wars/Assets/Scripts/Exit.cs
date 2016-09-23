using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {

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
        Application.Quit();
    }
}
