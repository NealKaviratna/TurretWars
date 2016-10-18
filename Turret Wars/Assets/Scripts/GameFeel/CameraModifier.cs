using System;
using UnityEngine;
using System.Collections;

public class CameraModifier : MonoBehaviour {

    private bool shaking = false;

    public void ShotFiredHandler(object sender, EventArgs e)
    {
        if (shaking) return;

        Weapon weapon = sender as Weapon;
        StartCoroutine(CameraShake(weapon.RecoilTime, weapon.KickBack));
    }

    public IEnumerator CameraShake(float duration, float magnitude)
    {
        shaking = true;
        //Debug.Log("Shaking: " + magnitude.ToString());
        float elapsed = 0.0f;

        Vector3 originalCamPos = Camera.main.transform.localPosition;

        while (elapsed < duration)
        {

            elapsed += Time.deltaTime;

            float percentComplete = elapsed / duration;
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

            // map value to [-1, 1]
            float x = UnityEngine.Random.value * 2.0f - 1.0f;
            float y = UnityEngine.Random.value * 2.0f - 1.0f;
            x *= magnitude * damper;
            y *= magnitude * damper;

            Camera.main.transform.localPosition = new Vector3(x, y, originalCamPos.z);

            yield return null;
        }

        Camera.main.transform.localPosition = originalCamPos;
        shaking = false;
    }
}
