using UnityEngine;
using System.Collections;

public abstract class IWeapon : MonoBehaviour {

    private int level;
    private float fireRate;

    private BulletBehaviour bulletBehaviour;

    public abstract void Fire();
}
