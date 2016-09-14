using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Script to animate 3D text effects in game.
/// </summary>
public class PickupNotificationBehaviour : MonoBehaviour
{

    public float Timer;

    void Start()
    {
        Timer = 2.0f;
    }

    void Update()
    {
        this.Timer -= Time.deltaTime;
        gameObject.transform.Translate(Vector3.up * 0.1f);

        if (this.Timer < 0)
            Destroy(this.gameObject);
    }
}
