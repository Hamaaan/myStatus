using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class isLoopDisplay : MonoBehaviour
{
    [SerializeField] GameObject LoopDisplay;
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = LoopDisplay.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (StaticValueManager.instance.isTimerOn)
        {
            text.text = "ループ : ON";
        }
        else
        {
            text.text = "ループ : OFF";
        }
    }
}
