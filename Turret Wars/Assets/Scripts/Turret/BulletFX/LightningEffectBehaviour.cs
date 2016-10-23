using UnityEngine;
using System.Collections;

public class LightningEffectBehaviour : EffectBehaviour
{
    protected override void Start()
    {
        base.Start();
        this.color = new Color(0, 0, 139, 100);
        this.Duration = 1.0f;
    }

    #region Effect

    private float originalSpeed;

    public override void ApplyEffect()
    {
        if (GetComponents<LightningEffectBehaviour>().Length > 1)
            Destroy(this);

        this.originalSpeed = GetComponent<BaseCreep>().Speed;
        GetComponent<BaseCreep>().Speed = 0;
    }

    public override void RemoveEffect()
    {
        GetComponent<BaseCreep>().Speed = this.originalSpeed;
    }

    public override string ToString()
    {
        return "LightningEffectBehaviour";
    }
    #endregion
}
