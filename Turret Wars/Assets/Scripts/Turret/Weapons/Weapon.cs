using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

/// <summary>
/// Interface class for weapons. Ensures all weapons interface properly with the rest of the game.
/// </summary>
/// 
public class Weapon : MonoBehaviour {

    protected int level;
    protected float fireRate;

    protected Image upgradeIcon;

    public Queue<Sprite> upgradeSprites;

    protected EffectBehaviour effect;
    public event EventHandler ShotFired;
    
    public float KickBack
    {
        get { return level / fireRate;  }
    }

    protected virtual void Awake()
    {
        this.ShotFired += GameObject.Find("GameFeel").GetComponent<CameraModifier>().ShotFiredHandler;
    }

    public virtual void Fire()
    {
        ShotFired(this, EventArgs.Empty);
    }

    public virtual void LevelUp()
    {
        if (this.upgradeIcon == null || upgradeSprites == null || upgradeSprites.Count == 0) return;

        upgradeIcon.sprite = upgradeSprites.Dequeue();
    }
}
