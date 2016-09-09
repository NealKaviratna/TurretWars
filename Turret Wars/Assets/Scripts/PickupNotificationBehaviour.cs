using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PickupNotificationBehaviour : MonoBehaviour
{

    public float Timer;

    // Use this for initialization
    void Start()
    {
        Timer = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        this.Timer -= Time.deltaTime;
        gameObject.transform.Translate(Vector3.up * 0.1f);

        if (this.Timer < 0)
            Destroy(this.gameObject);
    }
}
