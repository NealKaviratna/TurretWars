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

    public bool leftGun;

    public List<Vector2> mins;
    public List<Vector2> maxs;
    public List<Vector3> scales;

    private BankBehaviour bank;

    // Use this for initialization
    void Start()
    {
        if (!GetComponentInParent<NetworkIdentity>().isLocalPlayer) return;

        bank = GetComponentInParent<BankBehaviour>();

        mins = new List<Vector2>();
        maxs = new List<Vector2>();
        scales = new List<Vector3>();

        foreach(Transform child in GameObject.Find("UI:Weapons").transform)
        {
            UIPanels.Add(child.gameObject);
            mins.Add(child.gameObject.GetComponent<RectTransform>().anchorMin);
            maxs.Add(child.gameObject.GetComponent<RectTransform>().anchorMax);
            scales.Add(child.gameObject.GetComponent<RectTransform>().localScale);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponentInParent<NetworkIdentity>().isLocalPlayer) return;

        if (Input.GetKeyDown(KeyCode.Mouse1))
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
                int next = (i + 1) % Weapons.Count;
                Weapons[i].enabled = false;
                Weapons[next].enabled = true;
                break;
            }
        }

        for (int i = 0; i < Weapons.Count; i++)
        {
            int next = (i + 1) % Weapons.Count;
            SwitchUI(next, i);
        }

        UIPanels.Insert(0, UIPanels[UIPanels.Count - 1]);
        UIPanels.RemoveAt(UIPanels.Count - 1);
    }

    void SwitchUI(int next, int i)
    {
        if (leftGun) return;
        
        UIPanels[i].GetComponent<RectTransform>().anchorMin = mins[next];
        UIPanels[i].GetComponent<RectTransform>().anchorMax = maxs[next];
        UIPanels[i].GetComponent<RectTransform>().localScale = scales[next];
    }
}
