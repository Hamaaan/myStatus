using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DisplayCharaName : MonoBehaviour
{
    Text text;
    StaticValueManager _svm;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        _svm = StaticValueManager.instance;
        text.text = _svm.PlayerName;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
