using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class oboerumanager : MonoBehaviour
{
    //insert keypad5
    [SerializeField] private Text numberfifth;
    public int[] inputfifth;
    public int countfifth;
    public int allfifth;

    //randomoboeru
    public int originaloboeru;
    public Button btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn0, btnreset, btnenter;
    public float timecheck;
    public Text oboerutext;
    public float nokori;
    public Text nokoritext;
    public Text questionone;
    public Text questiontwo;


    public GameObject oboequestion;


    // Start is called before the first frame update
    void Start()
    {
        inputfifth = new int[4];

        randomoboeru();
    }

    // Update is called once per frame
    void Update()
    {
        randomtextfifth();

        oboeruquestion();
    }

    public void randomtextfifth()
    {
        allfifth = inputfifth[3] + inputfifth[2] * 10 + inputfifth[1] * 100 + inputfifth[0] * 1000;
    }

    public void clickfifth(int numberingfifth)
    {
        if (countfifth < 4)
        {
            inputfifth[countfifth] = numberingfifth;
            numberfifth.text = string.Join("", inputfifth);
            countfifth++;
        }
    }

    public void resetbuttonfifth()
    {
        for (int i = 0; i < 4; i++)
        {
            inputfifth[i] = 0;
            numberfifth.text = string.Join("", inputfifth);
            countfifth = 0;
        }
    }

    public void correctfifth()
    {
        if (allfifth == originaloboeru)
        {
            Debug.Log("correct");
            //timecheck = 0;
            //oboeruquestion();
            //randomoboeru();
            //resetbuttonfifth();
            //oboequestion.gameObject.SetActive(false);
            
        }
        else
        {
            Debug.Log("uncorrect");
            //timecheck = 0;
            //oboeruquestion();
            //randomoboeru();
            //resetbuttonfifth();
            //oboequestion.gameObject.SetActive(false);
            
        }
    }

    public void randomoboeru()
    {
        originaloboeru = Random.Range(1000, 10000);
        oboerutext.text = originaloboeru.ToString();
    }

    public void oboeruquestion()
    {
        timecheck += Time.deltaTime;
        nokori = 3 - timecheck;
        nokoritext.text = nokori.ToString("f0");

        if (timecheck < 3)
        {
            btn0.interactable = false;
            btn1.interactable = false;
            btn2.interactable = false;
            btn3.interactable = false;
            btn4.interactable = false;
            btn5.interactable = false;
            btn6.interactable = false;
            btn7.interactable = false;
            btn8.interactable = false;
            btn9.interactable = false;
            btnenter.interactable = false;
            btnreset.interactable = false;
        }
        else
        {
            btn0.interactable = true;
            btn1.interactable = true;
            btn2.interactable = true;
            btn3.interactable = true;
            btn4.interactable = true;
            btn5.interactable = true;
            btn6.interactable = true;
            btn7.interactable = true;
            btn8.interactable = true;
            btn9.interactable = true;
            btnenter.interactable = true;
            btnreset.interactable = true;

            oboerutext.gameObject.SetActive(false);

            questionone.gameObject.SetActive(false);
            questiontwo.gameObject.SetActive(false);
            nokoritext.gameObject.SetActive(false);

        }

    }

}
