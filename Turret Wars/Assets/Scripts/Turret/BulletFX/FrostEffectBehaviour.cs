using UnityEngine;
using System.Collections;

public class FrostEffectBehaviour : EffectBehaviour
{

    public float Duration = 5.0f;
    public float SlowAmount = 0.9f;

    private float timer;

    void Start()
    {
        timer = Duration;
        if (GetComponent<Weapon>() == null)
            this.ApplyEffect();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && GetComponent<Weapon>() == null)
        {
            Debug.Log(gameObject);
            Destroy(this);
        }
    }

    #region Effect
    public void ApplyEffect()
    {
        if (GetComponents<FrostEffectBehaviour>().Length > 1)
            Destroy(this);

        GetComponent<BaseCreep>().Speed *= SlowAmount;
    }

    public void RemoveEffect()
    {
        GetComponent<BaseCreep>().Speed /= SlowAmount;
    }

    public override string ToString()
    {
        return "FrostEffectBehaviour";
    }
    #endregion
}
