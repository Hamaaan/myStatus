using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickButtonManager : MonoBehaviour
{

    public Button btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9;

    [SerializeField] private Text Numtext;
    public string[] InputNumbers = new string[4];
    public int count;

    public NumberChant TimeUp;


    private void Start()
    {
        count = 0;
        //button.onClick.AddListener(OnClick);
        btn1.onClick.AddListener(() => OnClick(1));
        btn2.onClick.AddListener(() => OnClick(2));
        btn3.onClick.AddListener(() => OnClick(3));
        btn4.onClick.AddListener(() => OnClick(4));
        btn5.onClick.AddListener(() => OnClick(5));
        btn6.onClick.AddListener(() => OnClick(6));
        btn7.onClick.AddListener(() => OnClick(7));
        btn8.onClick.AddListener(() => OnClick(8));
        btn9.onClick.AddListener(() => OnClick(9));

        btn1.interactable = false;
        btn2.interactable = false;
        btn3.interactable = false;
        btn4.interactable = false;
        btn5.interactable = false;
        btn6.interactable = false;
        btn7.interactable = false; 
        btn8.interactable = false;
        btn9.interactable = false;
    }

    private void Update()
    {
        if(TimeUp.seconds == 0)
        {
            btn1.interactable = true;
            btn2.interactable = true;
            btn3.interactable = true;
            btn4.interactable = true;
            btn5.interactable = true;
            btn6.interactable = true;
            btn7.interactable = true;
            btn8.interactable = true;
            btn9.interactable = true;

        }
    }

    public void OnClick(int num)
    {
        if (count < 4)
        {
            InputNumbers[count] = "" + num;
            Numtext.text = string.Join("", InputNumbers);
            count++;
        }
    }
}
