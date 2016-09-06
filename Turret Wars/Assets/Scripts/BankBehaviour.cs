using UnityEngine;
using System.Collections;

public class BankBehaviour : MonoBehaviour {

    private float incomeTimer;
    private float incomeCycleLength = 10.0f;

    private int incomeAmount;
    private int gold;

    public float IncomeTimer
    {
        get { return incomeTimer; }
    }

    public int Gold
    {
        get { return gold; }
    }

	// Use this for initialization
	void Start () {
        incomeTimer = incomeCycleLength;

        incomeAmount = 100;
        gold = 100;
	}
	
	// Update is called once per frame
	void Update () {
        incomeTimer -= Time.deltaTime;

        if (incomeTimer < 0)
        {
            gold += incomeAmount;
            incomeTimer = incomeCycleLength;
        }
	}
}
