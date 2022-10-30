using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PomodoroTimer : MonoBehaviour
{
    float countTime = 30;

    bool TimerOn = false;
    bool isPause = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerOn)
        {
            CountDown();
        }

        GetComponent<Text>().text = countTime.ToString("F2");

        if (countTime < 0)
        {
            TimerOn = false;
            isPause = false;
        }
    }

    void CountDown()
    {
        // countTimeに、ゲームが開始してからの秒数を格納
        countTime -= Time.deltaTime;

        // 小数2桁にして表示
    }
    public void TimerStart(int t)
    {
        if (!isPause)
        {
            countTime = t;
        }
        TimerOn = true;
    }
    public void TimerPause()
    {
        TimerOn = false;
        isPause = true;
    }
}
