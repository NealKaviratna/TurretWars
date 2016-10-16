using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

/// <summary>
/// Interface class for weapons. Ensures all weapons interface properly with the rest of the game.
/// </summary>
public class Weapon : MonoBehaviour {

    protected int level;
    protected float fireRate;

    protected Image upgradeIcon;

    public Queue<Sprite> upgradeSprites;

    protected EffectBehaviour effect;

    public virtual void Fire()
    {

    }

    public virtual void LevelUp()
    {
        if (this.upgradeIcon == null || upgradeSprites == null || upgradeSprites.Count == 0) return;

        upgradeIcon.sprite = upgradeSprites.Dequeue();
    }
}
