﻿using UnityEngine;
using System.Collections;

/// <summary>
/// Simple Bullet Behaviour for use with Machine Gun and potentially Super Shotgun
/// </summary>
public class ShotgunPelletBehaviour : BasicBulletBehaviour {

    void Start()
    {
        this.speed = 120.0f;
        this.damageAmount = 5.0f;
    }

    public override string ToString()
    {
        return "ShotgunPellet";
    }
}
