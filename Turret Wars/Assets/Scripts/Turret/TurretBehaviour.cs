using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Will eventually be used to manage the Weapons system for each player.
/// </summary>
public class TurretBehaviour : MonoBehaviour
{

    public List<Weapon> Weapons;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            this.SwitchWeapon();
        }
    }

    void SwitchWeapon()
    {
        for (int i = 0; i < Weapons.Count; i++)
        {
            if (Weapons[i].enabled)
            {
                Weapons[i].enabled = false;
                Weapons[i + 1 < Weapons.Count ? i + 1 : 0].enabled = true;
                break;
            }
        }
    }
}
