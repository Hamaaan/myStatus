using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DungeonTimerManager : MonoBehaviour
{
    Text clock;
    TimeSpan setTimer;
    public int setTimeMin = 25;
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
        if (StaticValueManager.instance.ActiveSceneName == "Dungeon001")
        {
            if (!StaticValueManager.instance.isDungeonClear)
            {
                TimeCounter();
            }
            else
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    [SerializeField] GameObject FinishUI;

    void Finish()
    {
        StaticValueManager.instance.isRestTime = true;
        StaticValueManager.instance.isDungeonClear = true;
        Invoke("LoadHome", 5f);
    }

    void TimeCounter()
    {
        internel_timer += Time.deltaTime;

        string timer_str = setTimer.ToString();

        //clock.text = timer_str.Substring(timer_str.Length - 5);

        clock.text = timer_str.Substring(timer_str.Length - 5);

        if (new TimeSpan(0, 0, 0) >= setTimer)
        {
            Finish();
        }
        else
        {
            if (new TimeSpan(0, 5, 0) >= setTimer)
            {
                //time for bonus/rush
            }
            //Timerのカウント
            if (internel_timer > 1f)
            {
                setTimer -= new TimeSpan(0, 0, 1);
                internel_timer = 0f;
            }
        }
    }

    void LoadHome()
    {
        SceneManager.LoadScene("Home");
    }


    public void SetTime(int Min, int Sec)
    {
        setTimeMin = Min;
        setTimeSec = Sec;
        setTimer = new TimeSpan(0, setTimeMin, setTimeSec);
    }

    public void SetTimeSec(int Sec)
    {
        setTimeSec = Sec;
        setTimer = new TimeSpan(0, 0, setTimeSec);
    }
}
