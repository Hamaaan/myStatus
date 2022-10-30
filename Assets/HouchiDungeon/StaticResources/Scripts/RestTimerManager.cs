using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class RestTimerManager : MonoBehaviour
{
    Text clock;
    TimeSpan setTimer;
    public int setTimeMin = 5;
    public int setTimeSec = 0;

    float internel_timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        clock = GetComponent<Text>();
        SetTime(setTimeMin, setTimeSec);

    }

    private void OnEnable()
    {
        SetTime(setTimeMin, setTimeSec);
    }

    // Update is called once per frame
    void Update()
    {
        internel_timer += Time.deltaTime;

        string timer_str = setTimer.ToString();

        //clock.text = timer_str.Substring(timer_str.Length - 5);

        clock.text = timer_str.Substring(timer_str.Length - 5);

        if (new TimeSpan(0, 0, 0) >= setTimer)
        {
            StaticValueManager.instance.isRestTime = false;
            if (StaticValueManager.instance.isTimerOn)
            {
                SceneManager.LoadScene("Dungeon001");
            }
        }
        else
        {
            //Timerのカウント
            if (internel_timer > 1f)
            {
                setTimer -= new TimeSpan(0, 0, 1);
                internel_timer = 0f;
            }
        }
    }

    public void SetTime(int Min, int Sec)
    {
        setTimeMin = Min;
        setTimeSec = Sec;
        setTimer = new TimeSpan(0, setTimeMin, setTimeSec);
    }

    public void SetTimeMin(int Sec)
    {
        setTimeSec = Sec;
        setTimer = new TimeSpan(0, 0, setTimeSec);
    }

    public void SetTimeSec(int Sec)
    {
        setTimeSec = Sec;
        setTimer = new TimeSpan(0, 0, setTimeSec);
    }
}
