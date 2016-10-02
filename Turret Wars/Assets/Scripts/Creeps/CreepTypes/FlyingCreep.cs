using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Flying Creep 
/// Base Class for creeps. Inherit from this and adjust Creep region as necessary.
/// <see cref="WalkerCreep"/> for an example. Override Update loop for different movement.
/// </summary>
public class FlyingCreep : BaseCreep {


	#region IPoolable overrides


	public override string ToString()
	{
		return "BaseCreep";
	}

	public override void SetLevel(int level)
	{
		Debug.Log (level);
		this.maxHp = 50.0f;

		this.Hp = this.maxHp;
		this.Speed = 2.0f * (level / 2.0f);
		this.Value = 10 * level;
	}
	#endregion
}
