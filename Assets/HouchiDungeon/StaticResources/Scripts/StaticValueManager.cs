using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class StaticValueManager : MonoBehaviour
{
    //シングルトンの宣言
    public static StaticValueManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //PlayerData
    public string PlayerName = "ステモ";

    public int PlayerLevel = 1;
    public float PlayerExp = 1;
    public float PlayerHP = 5;
    public float PlayerPower = 5;
    public float PlayerDefence = 5;
    public float PlayerRange = 5;
    public float PlayerSpeed = 5;
    public int NumberOfKills = 0;

    public float MaxPlayerHP = 10;
    public float MaxPlayerPower = 10;
    public float MaxPlayerDefence = 10;
    public float MaxPlayerRange = 10;
    public float MaxPlayerSpeed = 10;

    public float NextExp = 50;
    public float BeforeExp = 0;
    public float StockExp = 0;

    public float BeforeTotalExp = 0;

    public float PlayerDistance = 0;


    //Dungeon
    public bool isDungeonClear = false;
    public bool isSpecial = false;
    //MinigameBuff
    public string PreMiniGameScene = "";

    //Home
    public bool isRestTime = false;

    //TimerSetting
    public bool isTimerOn = false;
    public bool isTimerStart = false;


    public TimeSpan RestTimerValue;

    //SceneManager
    public string ActiveSceneName;

    private void Start()
    {
        SceneManager.activeSceneChanged += ActiveSceneChanged;
        //PlayerName = OpeningSceneManager.GetUserName();
    }
    void ActiveSceneChanged(Scene thisScene, Scene nextScene)
    {
        //SceneBGM
        ActiveSceneName = SceneManager.GetActiveScene().name;

        if (ActiveSceneName == "Home")
        {
            isDungeonClear = false;

        }
        if (ActiveSceneName == "Dungeon001")
        {
            isTimerOn = true;
        }
        if (ActiveSceneName == "Intro")
        {

        }

    }

    public void subroutine()
    {
        Debug.Log("サブルーチンコール");
    }

    private void Update()
    {
        
    }
}
