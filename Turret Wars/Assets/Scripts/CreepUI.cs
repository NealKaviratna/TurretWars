using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreepUI : MonoBehaviour
{
    public Image TimerDisplay;
    public Text text; 

    private float timer;

    private int count;
    private int maxCount = 30;

    private int Count
    {
        get { return this.count; }
        set
        {
            this.count = value;
            this.text.text = this.count.ToString();
        }
    }

    public bool HasCreep
    {
        get
        {
            if (Count == 0)
                return false;
            else
            {
                Count--;
                return true;
            }
        }
    }

    // Use this for initialization
    void Start()
    {
        timer = 2.0f;
        count = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if (count < maxCount)
        {
            timer -= Time.deltaTime;
            TimerDisplay.fillAmount = timer / 2.0f;
            if (timer <= 0)
            {
                Count++;
                timer = 2.0f;
            }
        }
    }
}
