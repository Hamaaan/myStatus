using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusDisplay : MonoBehaviour
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
        GetComponent<Text>().text = "PlayerLevel : " + _svm.PlayerHP.ToString()
                                    + "\n" + "PlayerHP : " + _svm.PlayerHP.ToString();


    }
}
