using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

/// <summary>
/// Class for handling player income and gold. Attached to Player GameObject.
/// </summary>
public class BankBehaviour : NetworkBehaviour
{
    private float incomeTimer;
    private float incomeCycleLength = 10.0f;

    private float uiUpdateRate = 0.1f;
    private float timeAtUpdate = 10.0f;

    private int incomeAmount;
    private int gold;

    public float IncomeTimer
    {
        get { return incomeTimer; }
    }

    public int IncomeAmount
    {
        get { return incomeAmount; }
        set
        {
            this.incomeAmount = value;
            GameObject.Find("UI:Income").GetComponent<Text>().text = "+" + incomeAmount.ToString() + " in " + incomeTimer.ToString().Substring(0, 3);
        }
    }

    public int Gold
    {
        get { return gold; }
        set
        {
            this.gold = value;
            GameObject.Find("UI:Gold").GetComponent<Text>().text = "Gold: " + gold.ToString();
        }
    }

    // Use this for initialization
    void Start()
    {
        incomeTimer = incomeCycleLength;

        incomeAmount = 100;
        gold = 100;

        if (isLocalPlayer)
            GameObject.Find("UI:Gold").GetComponent<Text>().text = "Gold: " + gold.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer) return;
        incomeTimer -= Time.deltaTime;

        if (incomeTimer < timeAtUpdate - uiUpdateRate)
            GameObject.Find("UI:Income").GetComponent<Text>().text = "+" + incomeAmount.ToString() + " in " + incomeTimer.ToString().Substring(0,3);

        if (incomeTimer < 0)
        {
            gold += incomeAmount;
            incomeTimer = incomeCycleLength;
            timeAtUpdate = incomeCycleLength;
            GameObject.Find("UI:Gold").GetComponent<Text>().text = "Gold: " + gold.ToString();
        }
    }
}
