using UnityEngine;
using System.Collections;
using System;

public class TankCreep : BaseCreep
{

    #region IPoolable overrides
    /// <summary>
    /// Determines what prefab will be associated with this script.
    /// If testing code without model, return 'BaseCreep'
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return "TankCreep";
    }

    /// <summary>
    /// Adjust variables accordingly given the level of the creep. Called by Creep Factory.
    /// </summary>
    /// <param name="level">The level for the creep to be associated with</param>
    public override void SetLevel(int level)
    {
        this.maxHp = 300.0f * (level / 4.0f);

        this.Hp = this.maxHp;
        this.Speed = 0.025f * (level);
        this.Value = 15 * level;

        Color[] colors = { Color.green, Color.yellow, Color.red };
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
            r.material.SetColor("_GridColour", colors[level - 1]);
    }
    #endregion
}
