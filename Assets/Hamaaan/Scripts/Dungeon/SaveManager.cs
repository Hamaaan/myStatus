using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    StaticValueManager _svm; 
    // Start is called before the first frame update
    void Start()
    {
        _svm = StaticValueManager.instance;
        LoadData();
        SceneManager.activeSceneChanged += ActiveSceneChanged;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void ActiveSceneChanged(Scene thisScene, Scene nextScene)
    {
        if (nextScene.name != "Intro")
        {
            SaveData();
        }
        else
        {
            LoadData();
        }

        if (nextScene.name == "Opening 1")
        {
            ResetData();
            _svm.isTimerOn = false;
        }
        
        if (nextScene.name == "Home")
        {
            LoadData();
            Debug.Log("Home/Load");
        }
    }

    void LoadData()
    {
        _svm.PlayerName = PlayerPrefs.GetString("PlayerName", "ステモ");
        _svm.PlayerLevel = PlayerPrefs.GetInt("PlayerLevel", 1);
        _svm.PlayerExp = PlayerPrefs.GetFloat("PlayerExp", 1);
        _svm.PlayerHP = PlayerPrefs.GetFloat("PlayerHP", 5);
        _svm.PlayerPower = PlayerPrefs.GetFloat("PlayerPower", 5);
        _svm.PlayerDefence = PlayerPrefs.GetFloat("PlayerDefence", 5);
        _svm.PlayerRange = PlayerPrefs.GetFloat("PlayerRange", 5);
        _svm.PlayerSpeed = PlayerPrefs.GetFloat("PlayerSpeed", 5);
        _svm.NumberOfKills = PlayerPrefs.GetInt("NumberOfKills", 0);

        _svm.MaxPlayerHP = PlayerPrefs.GetFloat("MaxPlayerHP", 10);
        _svm.MaxPlayerPower = PlayerPrefs.GetFloat("MaxPlayerPower", 10);
        _svm.MaxPlayerDefence = PlayerPrefs.GetFloat("MaxPlayerDefence", 10);
        _svm.MaxPlayerRange = PlayerPrefs.GetFloat("MaxPlayerRange", 10);
        _svm.MaxPlayerSpeed = PlayerPrefs.GetFloat("MaxPlayerSpeed", 10);

        _svm.NextExp = PlayerPrefs.GetFloat("NextExp", 50);
        _svm.BeforeExp = PlayerPrefs.GetFloat("BeforeExp", 0);
        _svm.StockExp = PlayerPrefs.GetFloat("StockExp", 0);

        _svm.BeforeTotalExp = PlayerPrefs.GetFloat("BeforeTotalExp", 0);

        _svm.PlayerDistance = PlayerPrefs.GetFloat("PlayerDistance", 0);

        Debug.Log("Load");
    }


    void SaveData()
    {
        PlayerPrefs.SetString("PlayerName", _svm.PlayerName);
        PlayerPrefs.SetInt("PlayerLevel", _svm.PlayerLevel);
        PlayerPrefs.SetFloat("PlayerExp", _svm.PlayerExp);
        PlayerPrefs.SetFloat("PlayerHP", _svm.PlayerHP);
        PlayerPrefs.SetFloat("PlayerPower", _svm.PlayerPower);
        PlayerPrefs.SetFloat("PlayerDefence", _svm.PlayerDefence);
        PlayerPrefs.SetFloat("PlayerRange", _svm.PlayerRange);
        PlayerPrefs.SetFloat("PlayerSpeed", _svm.PlayerSpeed);
        PlayerPrefs.SetInt("NumberOfKills", _svm.NumberOfKills);

        PlayerPrefs.SetFloat("MaxPlayerHP", _svm.MaxPlayerHP);
        PlayerPrefs.SetFloat("MaxPlayerPower", _svm.MaxPlayerPower);
        PlayerPrefs.SetFloat("MaxPlayerDefence", _svm.MaxPlayerDefence);
        PlayerPrefs.SetFloat("MaxPlayerRange", _svm.MaxPlayerRange);
        PlayerPrefs.SetFloat("MaxPlayerSpeed", _svm.MaxPlayerSpeed);

        PlayerPrefs.SetFloat("NextExp", _svm.NextExp);
        PlayerPrefs.SetFloat("BeforeExp", _svm.BeforeExp);
        PlayerPrefs.SetFloat("StockExp", _svm.StockExp);

        PlayerPrefs.SetFloat("BeforeTotalExp", _svm.BeforeExp);

        PlayerPrefs.SetFloat("PlayerDistance", _svm.PlayerDistance);

        PlayerPrefs.Save();

        Debug.Log("Save");
    }

    void ResetData()
    {
        PlayerPrefs.SetString("PlayerName", "ステモ");
        PlayerPrefs.SetInt("PlayerLevel", 1);
        PlayerPrefs.SetFloat("PlayerExp", 1);
        PlayerPrefs.SetFloat("PlayerHP", 5);
        PlayerPrefs.SetFloat("PlayerPower", 5);
        PlayerPrefs.SetFloat("PlayerDefence", 5);
        PlayerPrefs.SetFloat("PlayerRange", 5);
        PlayerPrefs.SetFloat("PlayerSpeed", 5);
        PlayerPrefs.SetInt("NumberOfKills", 0);

        PlayerPrefs.SetFloat("MaxPlayerHP", 10);
        PlayerPrefs.SetFloat("MaxPlayerPower", 10);
        PlayerPrefs.SetFloat("MaxPlayerDefence", 10);
        PlayerPrefs.SetFloat("MaxPlayerRange", 10);
        PlayerPrefs.SetFloat("MaxPlayerSpeed", 10);

        PlayerPrefs.SetFloat("NextExp", 50);
        PlayerPrefs.SetFloat("BeforeExp", 0);
        PlayerPrefs.SetFloat("StockExp", 0);

        PlayerPrefs.SetFloat("BeforeTotalExp", 0);

        PlayerPrefs.SetFloat("PlayerDistance", 0);

        PlayerPrefs.Save();

        LoadData();

        Debug.Log("Reset");
    }


    /*
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
    */

}
