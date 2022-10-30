using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TimerStartManager : MonoBehaviour
{
    [SerializeField] GameObject StartButton;
    [SerializeField] GameObject DungeonTimer;
    [SerializeField] GameObject RestTimer;

    [SerializeField] GameObject SleepPlayer;
    [SerializeField] GameObject WakeupPlayer;

    GameObject BackCanvas;

    // Start is called before the first frame update
    void Start()
    {
        BackCanvas = GameObject.Find("BackCanvas");
        DungeonTimer = BackCanvas.transform.Find("DungeonTimer").gameObject;
        RestTimer = BackCanvas.transform.Find("RestTimer").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        StartButton.SetActive(!StaticValueManager.instance.isRestTime);

        /*
        DungeonTimer.SetActive(!StaticValueManager.instance.isRestTime);
        RestTimer.SetActive(StaticValueManager.instance.isRestTime);
        */

        SleepPlayer.SetActive(StaticValueManager.instance.isRestTime);
        WakeupPlayer.SetActive(!StaticValueManager.instance.isRestTime);

        
    }

    public void SceneChangeTo(int num)
    {
        SceneManager.LoadScene(num);
    }

    public void SceneChangeTo(string name)
    {
        SceneManager.LoadScene(name);
    }
}
