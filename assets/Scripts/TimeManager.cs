using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class TimeManager : MonoBehaviour
{
    private static TimeManager _instance;
    public static TimeManager Instance { get { return _instance; } }


    ScoreManager scoreManager;

    public TextMeshProUGUI minuteTextMeshPro;
    public TextMeshProUGUI secondTextMeshPro;
    public TextMeshProUGUI miliSecondTextMeshPro;

    public bool isResume;

    float minute;
    float second;
    [HideInInspector]
    public float miliSecond;

    private void Awake() { _instance = this; miliSecond = 0; second = 0; minute = 0; }

    private void Start() { scoreManager = ScoreManager.Instance; }

    void Update()
    {
        if (!isResume)
        {
            return;
        }
        else
        {            
            miliSecond += Time.deltaTime * 100;
        }
        //if (miliSecond <= 99)
       // {
            miliSecondTextMeshPro.SetText(Mathf.Round(miliSecond).ToString());
       // }
        if (miliSecond >= 100)
        {
            miliSecond = 0f;
            miliSecondTextMeshPro.SetText(Mathf.Round(miliSecond).ToString() + "0");
            second++;

            if (second <= 59)
            {
                if (second <= 9)
                {
                    secondTextMeshPro.SetText("0" + second.ToString());
                }
                else if (second >= 10)
                {
                    secondTextMeshPro.SetText(second.ToString());
                }
            }
            else if (second >= 60)
            {
                second = 0;
                minute++;               
                if (minute <= 9)
                {
                    minuteTextMeshPro.SetText("0" + minute.ToString());
                }
                else if (minute >= 10)
                {
                    minuteTextMeshPro.SetText(minute.ToString());
                }
            }
        }
      
    }


    public void ResetAll()
    {
        miliSecond = 0; second = 0; minute = 0;
        miliSecondTextMeshPro.SetText("00");
        secondTextMeshPro.SetText("00");
        minuteTextMeshPro.SetText("00");
    }//scoreManager.score = 0; }
}
