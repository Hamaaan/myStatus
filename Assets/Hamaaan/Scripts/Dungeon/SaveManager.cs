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
        SaveData();
        Debug.Log("Save");
    }

    void LoadData()
    {
        _svm.PlayerName = PlayerPrefs.GetString("PlayerName", _svm.PlayerName);
        _svm.PlayerLevel = PlayerPrefs.GetInt("PlayerLevel", _svm.PlayerLevel);
        _svm.PlayerExp = PlayerPrefs.GetFloat("PlayerExp", _svm.PlayerExp);
        _svm.PlayerHP = PlayerPrefs.GetFloat("PlayerHP", _svm.PlayerHP);
        _svm.PlayerPower = PlayerPrefs.GetFloat("PlayerPower", _svm.PlayerPower);
        _svm.PlayerDefence = PlayerPrefs.GetFloat("PlayerDefence", _svm.PlayerDefence);
        _svm.PlayerRange = PlayerPrefs.GetFloat("PlayerRange", _svm.PlayerRange);
        _svm.PlayerSpeed = PlayerPrefs.GetFloat("PlayerSpeed", _svm.PlayerSpeed);
        _svm.NumberOfKills = PlayerPrefs.GetInt("NumberOfKills", _svm.NumberOfKills);
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

        PlayerPrefs.Save();
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
    */
}
