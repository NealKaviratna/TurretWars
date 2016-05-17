using UnityEngine;
using System.Collections;
/// <summary>
/// IPoolable interface.
/// </summary>
/// 
/// <remarks>
/// This should really be a interface, hence the name and implementation. But Unity is 
/// dumb and does not provide a Monobehaviour Interface. So this is abstract.
/// </remarks>
public abstract class IPoolable : MonoBehaviour {

    public abstract uint ObjectId
    {
        get;
    }


    public abstract bool InUse {
        get;
    }

    public abstract IPoolable Create(Player creator, uint objectId);

    public abstract void Die();

    public abstract void Recall();

    public abstract override string ToString();
}
