using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

/// <summary>
/// Class for handling player income and gold. Attached to Player GameObject.
/// </summary>
public class BankBehaviour : NetworkBehaviour
{
    public bool start = false;

    private float incomeTimer;
    private float incomeCycleLength = 10.0f;

    private float uiUpdateRate = 0.1f;
    private float timeAtUpdate = 10.0f;

    private int incomeAmount;
    private int gold;

    private Text UIGoldText;
    private Text UIIncomeText;
    private Image UITimer;

    public float IncomeTimer
    {
        get { return incomeTimer; }
        set
        {
            if (incomeTimer < timeAtUpdate - uiUpdateRate)
                GameObject.Find("UI:IncomeTimer").GetComponent<Image>().fillAmount = 1 - (value / incomeCycleLength);
            
            incomeTimer = value;
        }
    }

    public int IncomeAmount
    {
        get { return incomeAmount; }
        set
        {
            this.incomeAmount = value;
            GameObject.Find("UI:Income").GetComponent<Text>().text = "+" + incomeAmount.ToString();
        }
    }

    public int Gold
    {
        get { return gold; }
        set
        {
            this.gold = value;
            GameObject.Find("UI:Gold").GetComponent<Text>().text = gold.ToString();
        }
    }

    // Use this for initialization
    public override void OnStartClient()
    {
        base.OnStartClient();
        IncomeTimer = incomeCycleLength;

        IncomeAmount = 100;
        Gold = 100;

        if (isLocalPlayer)
        {
            //todo: figure out setup bugs on Bank Behaivour
            //UIGoldText = GameObject.Find("UI:Gold").GetComponent<Text>();
            GameObject.Find("UI:Gold").GetComponent<Text>().text = gold.ToString();

            //UIIncomeText = GameObject.Find("UI:Income").GetComponent<Text>();

            //UITimer = GameObject.Find("UI:IncomeTimer").GetComponent<Image>();
            //Debug.Log(GameObject.Find("UI:IncomeTimer"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer || !start) return;
        IncomeTimer -= Time.deltaTime;

        if (incomeTimer < 0)
        {
            gold += incomeAmount;
            IncomeTimer = incomeCycleLength;
            timeAtUpdate = incomeCycleLength;
            GameObject.Find("UI:Gold").GetComponent<Text>().text = gold.ToString();
        }
    }
}
