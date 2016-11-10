using UnityEngine;
using System;

class FlankCreep : BaseCreep
{
    /// <summary>
    /// Transform calculated to be to the side of the enemy tower
    /// </summary>
    private Vector3 flankTarget;
    private bool flanked;

    #region IPoolable overrides
    public override Poolable Create(Player creator, uint creepId, Vector3 position)
    {
        flanked = false;
        flankTarget = creator.targetBattlezone.Nexus.transform.position;
        flankTarget.x += UnityEngine.Random.Range(0.0f, 1.0f) > .5f ? 12 : -12;
        flankTarget.z += 15;
        return base.Create(creator, creepId, position);
    }

    protected override void Update()
    {
        if (Vector3.Distance(flankTarget, this.transform.position) < 3)
            flanked = true;
        if(flanked)
            transform.position = Vector3.MoveTowards(transform.position, target.position, Speed);
        else
            transform.position = Vector3.MoveTowards(transform.position, flankTarget, Speed);

        base.Update();
    }

    /// <summary>
    /// Determines what prefab will be associated with this script.
    /// If testing code without model, return 'BaseCreep'
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return "FlankCreep";
    }

    /// <summary>
    /// Adjust variables accordingly given the level of the creep. Called by Creep Factory.
    /// </summary>
    /// <param name="level">The level for the creep to be associated with</param>
    public override void SetLevel(int level)
    {
        this.maxHp = 100.0f;

        this.Hp = this.maxHp;
        this.Speed = 0.1f * (level / 2.0f);
        this.Value = 10 * level;


        Color[] colors = { Color.green, Color.yellow, Color.red };
        Color[] basecolors = { Color.white, Color.black };

        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            r.material.SetColor("_GridColour", colors[level - 1]);
            r.material.SetColor("_BaseColour", basecolors[(int) Math.Ceiling(level / 3.0)]);
        }
    }
    #endregion


}
