using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    StaticValueManager _svm; 
    // Start is called before the first frame update
    void Start()
    {
        _svm = StaticValueManager.instance;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SaveData()
    {


        PlayerPrefs.SetInt("isIntro", 0);




        PlayerPrefs.Save();

    }


    /*
    public float PlayerLevel = 1;
    public float PlayerExp = 1;
    public float PlayerHP = 5;
    public float PlayerPower = 5;
    public float PlayerDefence = 5;
    public float PlayerRange = 5;
    public float PlayerSpeed = 5;
    public int NumberOfKills = 0;
    */
}
