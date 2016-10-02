using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

/// <summary>
/// Abstract class for weapons. Ensures all weapons interface properly with the rest of the game.
/// </summary>
public abstract class Weapon : MonoBehaviour {

    protected int level;
    protected float fireRate;

    public abstract void Fire();
}
