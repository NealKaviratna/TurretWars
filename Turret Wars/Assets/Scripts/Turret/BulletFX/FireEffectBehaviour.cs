using UnityEngine;
using System.Collections;

public class FireEffectBehaviour : EffectBehaviour
{
    protected override void Start()
    {
        base.Start();
        this.color = Color.red;

        damageRate = 0.5f;
        damageTimer = 0.5f;
        isActive = false;
    }

    #region Effect

    public float damageAmount = 0.8f;
    private float damageRate;
    private float damageTimer;

    private bool isActive;

    private BaseCreep target;

    protected override void Update()
    {
        base.Update();
        if (timer > damageTimer && isActive)
        {
            target.Hp -= damageAmount;
            damageTimer += damageRate;
        }
    }

    public override void ApplyEffect()
    {
        if (GetComponents<FireEffectBehaviour>().Length > 1)
            Destroy(this);

        target = GetComponent<BaseCreep>();
        if (target == null)
            Destroy(this);
        this.isActive = true;
    }

    public override void RemoveEffect()
    {
        this.isActive = false;
    }

    public override string ToString()
    {
        return "FireEffectBehaviour";
    }
    #endregion
}
