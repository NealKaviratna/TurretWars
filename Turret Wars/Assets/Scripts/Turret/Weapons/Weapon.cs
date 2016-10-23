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
public class Weapon : MonoBehaviour
{

    public int UpgradePrice;

    protected int level;
    protected float fireRate;

    public Image upgradeIcon;
    public Queue<Sprite> upgradeSprites;

    protected EffectBehaviour effect;
    public event EventHandler ShotFired;
    public AudioClip ShotSFX;

    private BankBehaviour bank;

    public float KickBack
    {
        get { return (level+1) * fireRate * .1f;  }
    }

    /// <summary>
    /// How long should this weapon shake?
    /// </summary>
    public float RecoilTime
    {
        get { return fireRate / 2.0f; }
    }

    protected virtual void Awake()
    {
        this.UpgradePrice = 100;
        this.bank = GetComponentInParent<BankBehaviour>();

        this.ShotFired += GameObject.Find("GameFeel").GetComponent<CameraModifier>().ShotFiredHandler;
        this.ShotFired += GameObject.Find("GameFeel").GetComponent<SoundPlayer>().ShotFiredHandler;

        upgradeIcon.gameObject.SetActive(false);
    }

    public virtual void Fire()
    {
        if (ShotFired != null)
            this.ShotFired(this, EventArgs.Empty);
    }

    protected virtual void Update()
    {
        if (!gameObject.transform.parent.gameObject.GetComponent<NetworkIdentity>().isLocalPlayer) return;

        if (Input.GetKeyDown(KeyCode.U) && bank.Gold >= this.UpgradePrice * 3)
        {
            bank.Gold -= this.UpgradePrice;
            this.LevelUp();
            this.UpgradePrice *= 2;
        }
    }

    public virtual void LevelUp()
    {
        if (this.upgradeIcon == null || upgradeSprites == null || upgradeSprites.Count == 0) return;

        Sprite temp = upgradeSprites.Dequeue();

        Debug.Log(temp);

        upgradeIcon.sprite = temp;
    }
}
