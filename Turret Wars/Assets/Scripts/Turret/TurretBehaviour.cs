using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Will eventually be used to manage the Weapons system for each player.
/// </summary>
public class TurretBehaviour : NetworkBehaviour
{

    public List<Weapon> Weapons;
    public List<GameObject> UIPanels;

    private BankBehaviour bank;

    // Use this for initialization
    void Start()
    {
        if (!GetComponentInParent<NetworkIdentity>().isLocalPlayer) return;

        bank = GetComponentInParent<BankBehaviour>();

        foreach(Transform child in GameObject.Find("UI:Weapons").transform)
        {
            UIPanels.Add(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponentInParent<NetworkIdentity>().isLocalPlayer && Input.GetKeyDown(KeyCode.Mouse1))
        {
            this.SwitchWeapon();
        }

        foreach(Weapon weapon in Weapons)
        {
            if (weapon.UpgradePrice * 3 <= bank.Gold)
            {
                weapon.upgradeIcon.gameObject.SetActive(true);
                weapon.upgradeIcon.GetComponentInChildren<Text>().text = (2 * weapon.UpgradePrice).ToString();
            }
            else
                weapon.upgradeIcon.gameObject.SetActive(false);
        }

    }

    void SwitchWeapon()
    {
        for (int i = 0; i < Weapons.Count; i++)
        {
            if (Weapons[i].enabled)
            {
                Weapons[i].enabled = false;
                UIPanels[i].GetComponent<Image>().color = new Color(100, 100, 100, 0);
                int next = i + 1 < Weapons.Count ? i + 1 : 0;
                Weapons[next].enabled = true;
                UIPanels[next].GetComponent<Image>().color = new Color(255, 255, 255, 255);
                break;
            }
        }
    }
}
