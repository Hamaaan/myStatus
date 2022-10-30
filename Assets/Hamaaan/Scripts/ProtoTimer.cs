using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProtoTimer : MonoBehaviour
{
    [SerializeField] float Timer = 0f;

    [SerializeField] Text text;

    bool isTimerOn = false;

    [SerializeField] GameObject StopWatch;

    // Start is called before the first frame update
    void Start()
    {
        text = text.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (StopWatch.activeSelf)
        {
            isTimerOn = true;
        }

        if (!StopWatch.activeSelf)
        {
            isTimerOn = false;
            Timer = 0f;
        }

        if (isTimerOn)
        {
            Timer += Time.deltaTime;
        }

        if ((int)Timer>3600)
        {
            text.text = ((int)Timer / 3660).ToString("00") + ":" + ((int)Timer / 60).ToString("00") + ":" + ((int)Timer % 60).ToString("00");
        }
        else
        {
            text.text = ((int)Timer / 60).ToString("00") + ":" + ((int)Timer % 60).ToString("00");
        }
    }
}
