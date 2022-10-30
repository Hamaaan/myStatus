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
    public float PlayerLevel = 1;
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

    //Dungeon
    public bool isDungeonClear = false;
    public bool isSpecial = false;

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
    }

    public void subroutine()
    {
        Debug.Log("サブルーチンコール");
    }

    private void Update()
    {
        
    }
}
