using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour {

    private int level;
    private float fireRate;

    private BulletBehaviour bulletBehaviour;

    public abstract void Fire();
}
