using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIManager : MonoBehaviour
{
    [SerializeField] GameObject MainUI;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (StaticValueManager.instance.ActiveSceneName == "IQ_puzzle1"
            || StaticValueManager.instance.ActiveSceneName == "IQ_KigouSagashi 1"
            || StaticValueManager.instance.ActiveSceneName == "testcoin 2"
            || StaticValueManager.instance.ActiveSceneName == "testoboeru 1"
            || StaticValueManager.instance.ActiveSceneName == "testomori 1")
        {
            MainUI.SetActive(false);
        }
        else
        {
            MainUI.SetActive(true);
        }
    }
}
