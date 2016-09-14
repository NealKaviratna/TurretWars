using UnityEngine;
using System.Collections;
/// <summary>
/// Abstract class for objects that can be contained in <see cref="ObjectPool{T}"/>.
/// </summary>
/// 
/// <remarks>
/// This should really be a interface, hence the name and implementation. But Unity is 
/// dumb and does not provide a Monobehaviour Interface. So this is abstract.
/// </remarks>
public abstract class Poolable : MonoBehaviour {

    public abstract uint ObjectId
    {
        get;
    }


    public abstract bool InUse {
        get;
    }

    public abstract Poolable Create(Player creator, uint objectId, Vector3 position);

    public abstract void Die();

    public abstract void Recall();

    public abstract override string ToString();
}
