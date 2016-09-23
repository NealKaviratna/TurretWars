using UnityEngine;
using System.Collections;
using System;

public class WalkerCreep : BaseCreep
{

    #region IPoolable overrides
    /// <summary>
    /// Determines what prefab will be associated with this script.
    /// If testing code without model, return 'BaseCreep'
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return "WalkerCreep";
    }

    /// <summary>
    /// Adjust variables accordingly given the level of the creep. Called by Creep Factory.
    /// </summary>
    /// <param name="level">The level for the creep to be associated with</param>
    public override void SetLevel(int level)
    {
        this.maxHp = 100.0f * (level / 4.0f);

        this.hp = this.maxHp;
        this.speed = 0.5f * (level);
        this.value = 10 * level;


        Color[] colors = { Color.green, Color.yellow, Color.red };
        GetComponentInChildren<Renderer>().material.color = colors[level - 1];
    }
    #endregion
}
