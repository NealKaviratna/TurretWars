using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour {

    protected int level;
    protected float fireRate;

    private BulletBehaviour bulletBehaviour;

    public abstract void Fire();
}
