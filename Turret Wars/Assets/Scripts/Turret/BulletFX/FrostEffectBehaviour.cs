using UnityEngine;
using System.Collections;

public class FrostEffectBehaviour : EffectBehaviour
{
    protected override void Start()
    {
        base.Start();
        this.color = Color.cyan;
    }

    #region Effect

    public float SlowAmount = 0.9f;

    public override void ApplyEffect()
    {
        if (GetComponents<FrostEffectBehaviour>().Length > 1)
            Destroy(this);

        GetComponent<BaseCreep>().Speed *= SlowAmount;
    }

    public override void RemoveEffect()
    {
        GetComponent<BaseCreep>().Speed /= SlowAmount;
    }

    public override string ToString()
    {
        return "FrostEffectBehaviour";
    }
    #endregion
}
