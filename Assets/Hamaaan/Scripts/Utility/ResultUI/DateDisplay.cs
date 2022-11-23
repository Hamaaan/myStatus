using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DateDisplay : MonoBehaviour
{
    [SerializeField] Text DateText;
    [SerializeField] Text DistanceText;
    [SerializeField] Text ExpText;
    [SerializeField] Text NextText;

    DateTime Today;


    StaticValueManager _svm;

    //_svmから値を取って各テキストに反映する


    // Start is called before the first frame update
    void Start()
    {
        Today = DateTime.Now;

        DateText = DateText.GetComponent<Text>();
        DistanceText = DistanceText.GetComponent<Text>();
        ExpText = ExpText.GetComponent<Text>();
        NextText = NextText.GetComponent<Text>();

        _svm = StaticValueManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        DateText.text = Today.Year.ToString() + Today.Month.ToString() + Today.Day.ToString();

        DistanceText.text = _svm.PlayerDistance.ToString("N2");
        ExpText.text = _svm.BeforeTotalExp.ToString();
        NextText.text = _svm.NextExp.ToString();
    }
}
