using UnityEngine;
using System.Collections;
using System;

public class WalkerCreep : BaseCreep
{

    #region Creep

    private float maxHp = 100.0f;
    private uint creepId;

    public new float hp = 100.0f;
    public new float speed = 0.07f;
    public new int value = 10;
    #endregion

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
        this.speed = 0.5f * (level * 2);
        this.value = 10 * level;


        Color[] colors = { Color.green, Color.yellow, Color.red };
        GetComponent<Renderer>().material.color = colors[level - 1];
    }
    #endregion
}
