﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class inputnumber : MonoBehaviour
{
    // insert keypad
    [SerializeField] private Text number;
    public int[] input;
    public int count;
    public int all;

    // insert keypad2
    [SerializeField] private Text numbersecond;
    public int[] inputsecond;
    public int countsecond;

    //insert keypad3
    [SerializeField] private Text numberthird;
    [SerializeField] private Text numberthirdtwo;
    public int[] inputthird;
    public int[] inputthirdtwo;

    public int countthird;
    public int countthirdtwo;

    public float allthirdup;
    public float allthirddown;
    public float allupdown;

    //insert keypad4
    [SerializeField] private Text numberforth;
    public int[] inputforth;
    public int countforth;
    public int allforth;

    //insert keypad5
    [SerializeField] private Text numberfifth;
    public int[] inputfifth;
    public int countfifth;
    public int allfifth;

    // question random number
    public Text randomone;
    public Text randomtwo;

    public int ranone;
    public int rantwo;

    // answer number
    public Text answertext; 
    public int answer;

    // correct count
    public int correctcount;
    public Text counttext;

    public GameObject calculate;

    //coin apple, mikkan image
    public int coinranapple;
    public Image[] apple;

    public int coinranmikan;
    public Image[] mikan;

    // coin appple, mikkan random price
    public int appleprice;
    public int mikanprice;

    public int allprice;

    public int allsecond;

    public Text publicappleprice;
    public Text publicmikanprice;

    public int allcoin;

    public Text pricecorrecttext;

    // percent quesiton random
    public float blue;
    public float red;
    public int questionrandomcolor;

    public Text bluetext;
    public Text redtext;
    public Text quesitoncolor;

    public int allcolor;

    public Text questionanswertext;

    //question random

    public int randomquestion;
    public GameObject calculatequestion;
    public GameObject coinquestion;
    public GameObject questionquestion;
    public GameObject percentquestion;
    public GameObject oboequestion;

    //price random
    public float originalprice;
    public float pricepercent;
    public float sale;
    public float afterprice;

    public int pricepercentswitch;
    public int saleswitch;
    public float salefirst;
    public float originapricefirst;

    public Text percenttext;
    public Text saletext;
    public Text pricetext;

    public Text percentcorrecttext;

    //randomoboeru
    public int originaloboeru;
    public Button btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn0, btnreset, btnenter;
    public float timecheck;
    public Text oboerutext;
    public float nokori;
    public Text nokoritext;
    public Text questionone;
    public Text questiontwo;

    // audio
    public AudioSource correctsound;
    public AudioSource uncorrectsound;
    public AudioSource pushsound;

    //counttime
    public float counttime;
    public float limittime;
    public float remaintime;
    public Text counttimetext;
    
    

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        correctcount = 0;
        
        input = new int[4];
        inputsecond = new int[4];
        inputthird = new int[2];
        inputthirdtwo = new int[2];
        inputforth = new int[5];
        inputfifth = new int[4];

        count = 0;
        
       



       randomquest();

        coinswitch();
        randomcolor();
        randomprice();
        randomoboeru();
    }

    private void Awake()
    {
        randomnumber();
        
    }

    // Update is called once per frame
    void Update()
    {
        randomtext();
        randomtextsecond();
        randomtextthird();
        randomtextforth();
        randomtextfifth();

        oboeruquestion();

        timer();
    }

    public void timer()
    {
        counttime += Time.deltaTime;
        remaintime = limittime - counttime;
        counttimetext.text = remaintime.ToString("f0");
    }
    

    void randomtext()
    {
        randomone.text = ranone.ToString();
        randomtwo.text = rantwo.ToString();
        counttext.text = correctcount.ToString();

        answer = rantwo + ranone;

        if(answer>= 1000)
        {
            all = input[3] + input[2] * 10 + input[1] * 100 + input[0] * 1000;
        }
        else if(answer < 1000)
        {
            all = input[3] + input[2] * 10 + input[1] * 100;
        }
        
    }

    void randomtextsecond()
    {
        if(allprice>= 1000)
        {
            allsecond = inputsecond[3] + inputsecond[2] * 10 + inputsecond[1] * 100 + inputsecond[0] * 1000;
        }
        else if (all < 1000)
        {
            allsecond = inputsecond[3] + inputsecond[2] * 10 + inputsecond[1] * 100 ;
        }

    }

    public void randomtextthird()
    {
        allthirddown = inputthirdtwo[1] + inputthirdtwo[0] * 10;
        allthirdup = inputthird[1] + inputthird[0] * 10;       
    }

    public void randomtextforth()
    {
        if (originalprice >= 10000)
        {
            
            allforth = inputforth[4] + inputforth[3] * 10 + inputforth[2] * 100 + inputforth[1] * 1000 + inputforth[0] * 10000;
        }
        else if(10000>originalprice && originalprice >= 1000)
        {
            
            
            allforth = inputforth[4] + inputforth[3] * 10 + inputforth[2] * 100 + inputforth[1] * 1000;
        }
        else if(originalprice<1000)
        {
            
            allforth = inputforth[4] + inputforth[3] * 10 + inputforth[2] * 100;
        }
       
    }

    public void randomtextfifth()
    {
        allfifth = inputfifth[3] + inputfifth[2] * 10 + inputfifth[1] * 100 + inputfifth[0] * 1000;
    }



    public void click(int numbering)
    {
        if (answer >= 1000)
        {
            if (count < 4)
            {
                input[count] = numbering;
                number.text = string.Join("", input);
                count++;
            }
        }

        else if(answer < 1000)
        {
            if (count < 3)
            {
                input[count+1] = numbering;
                number.text = string.Join("", input);
                count++;
            }
        }

    }

    public void clicksecond(int numberingsecond)
    {
        if (allprice >= 1000)
        {
            if (countsecond < 4)
            {
                inputsecond[countsecond] = numberingsecond;
                numbersecond.text = string.Join("", inputsecond);
                countsecond++;
            }
        }
        else if (allprice < 1000)
        {
            if (countsecond < 3)
            {
                inputsecond[countsecond+1] = numberingsecond;
                numbersecond.text = string.Join("", inputsecond);
                countsecond++;
            }
        }
        

    }
    public void clickthird(int numberingthird)
    {
        if(countthird <2)
        {
            
                inputthird[countthird] = numberingthird;
                numberthird.text = string.Join("", inputthird);
                countthird++;
            
        }
        else
        {
                if (countthirdtwo < 2)
                {
                    inputthirdtwo[countthirdtwo] = numberingthird;
                    numberthirdtwo.text = string.Join("", inputthirdtwo);
                    countthirdtwo++;
                }  
        }
        
    }

    public void clickforth(int numberingforth)
    {

        if (originalprice >= 10000)
        {
            if (countforth < 5)
            {
                inputforth[countforth] = numberingforth;
                numberforth.text = string.Join("", inputforth);
                countforth++;



            }
        }

        else if (10000 > originalprice && originalprice >= 1000)
        {
            if (countforth < 4)
            {
                inputforth[countforth+1] = numberingforth;
                numberforth.text = string.Join("", inputforth);
                countforth++;

            }
        }
        else if (originalprice<1000)
        {
            inputforth[countforth+2] = numberingforth;
            numberforth.text = string.Join("", inputforth);
            countforth++;
        }


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

   

    public void resetbutton()
    {
        for (int i = 0; i < 4; i++)
        {
            input[i] = 0;
            number.text = string.Join("", input);
            count = 0;
        }
    }

    public void resetbuttonsecond()
    {
        for (int i = 0; i < 4; i++)
        {
            inputsecond[i] = 0;
            numbersecond.text = string.Join("", inputsecond);
            countsecond = 0;
        }
    }

    public void resetbuttonthird()
    {
        for (int i = 0; i < 2; i++)
        {
            inputthird[i] = 0;
            inputthirdtwo[i] = 0;
            numberthird.text = string.Join("", inputthird);
            numberthirdtwo.text = string.Join("", inputthirdtwo);

            countthird = 0;
            countthirdtwo = 0;
        }
    }

    public void resetbuttonforth()
    {
            for (int i = 0; i < 5; i++)
            {
                inputforth[i] = 0;
                numberforth.text = string.Join("", inputforth);
                countforth = 0;
            }

    }

    public void resetbuttonfifth()
    {
        for(int i = 0; i<4; i++)
        {
            inputfifth[i] = 0;
            numberfifth.text = string.Join("", inputfifth);
            countfifth = 0;
        }
    }


    public void randomnumber()
    {
        ranone = Random.Range(50, 91) * 10;
        rantwo = Random.Range(50, 91) * 10;

    }


    public void correct()
    {
        
            if (all == answer)
            {
                answertext.text = "correct";
                randomnumber();
                resetbutton();
            calculatequestion.gameObject.SetActive(false);
            randomquest();
            pushsound.Play();
            correctcount++;
            timecheck = 0;
            }
            else
            {
                answertext.text = "uncorrect";
                randomnumber();
                resetbutton();
            pushsound.Play();
            calculatequestion.gameObject.SetActive(false);
            randomquest();
            timecheck = 0;
        }


    }

    public void correctsecond()
    {

        if (allsecond == allprice)
        {
            pricecorrecttext.text = "correct";
            apple[coinranapple - 1].gameObject.SetActive(false);
            mikan[coinranmikan - 1].gameObject.SetActive(false);

            coinswitch();
            resetbuttonsecond();
            correctcount++;
            pushsound.Play();
            coinquestion.gameObject.SetActive(false);
            randomquest();
            timecheck = 0;
        }
        else
        {
        pricecorrecttext.text = "uncorrect";

            apple[coinranapple - 1].gameObject.SetActive(false);
            mikan[coinranmikan - 1].gameObject.SetActive(false);

            pushsound.Play();
            resetbuttonsecond();
            coinswitch();
            coinquestion.gameObject.SetActive(false);
            randomquest();
            timecheck = 0;
        }


    }

    public void correctthird()
    {
        if(questionrandomcolor == 1)
        {
            if(allthirdup/allthirddown == blue/(blue+ red))
            {
                //questionanswertext.text = "correct";
                randomcolor();
                resetbuttonthird();
                correctcount++;
                pushsound.Play();
                questionquestion.gameObject.SetActive(false);
                randomquest();
                Debug.Log("1");
                timecheck = 0;

            }
            else 
            {
                //questionanswertext.text = "uncorrect";
                randomcolor();
                resetbuttonthird();
                pushsound.Play();
                questionquestion.gameObject.SetActive(false);
                randomquest();
                Debug.Log("2");
                timecheck = 0;
            }
        }

        if (questionrandomcolor == 2)
        {
            if (allthirdup / allthirddown == red / (blue + red))
            {
                //questionanswertext.text = "correct";
                randomcolor();
                resetbuttonthird();                
                correctcount++;
                pushsound.Play();
                questionquestion.gameObject.SetActive(false);
                randomquest();
                Debug.Log("3");
                timecheck = 0;

            }
            else
            {
                //questionanswertext.text = "uncorrect";
                randomcolor();
                resetbuttonthird();
                pushsound.Play();
                questionquestion.gameObject.SetActive(false);
                randomquest();
                Debug.Log("4");
                timecheck = 0;
            }
        }



    }

    public void correctforth()
    {
        if(allforth == originalprice)
        {
            percentcorrecttext.text = "correct";
            randomprice();
            pushsound.Play();
            resetbuttonforth();
            percentquestion.gameObject.SetActive(false);
            randomquest();
            timecheck = 0;
        }
        else
        {
            percentcorrecttext.text = "uncorrect";
            randomprice();
            resetbuttonforth();
            pushsound.Play();
            percentquestion.gameObject.SetActive(false);
            randomquest();
            timecheck = 0;

        }
    }

    public void correctfifth()
    {
        if(allfifth == originaloboeru)
        {
            Debug.Log("correct");
            timecheck = 0;
            oboeruquestion();
            randomoboeru();
            resetbuttonfifth();
            oboequestion.gameObject.SetActive(false);
            randomquest();
        }
        else
        {
            Debug.Log("uncorrect");
            timecheck = 0;
            oboeruquestion();
            randomoboeru();
            resetbuttonfifth();
            oboequestion.gameObject.SetActive(false);
            randomquest();
        }
    }


    public void coinswitch()
    {
        coinranapple = Random.Range(1, 10);
        coinranmikan = Random.Range(1, 10);

        appleprice = Random.Range(5, 21) * 10;
        mikanprice = Random.Range(3, 13) * 10;

        allprice = coinranapple * appleprice + coinranmikan * mikanprice;

        publicappleprice.text = appleprice.ToString();
        publicmikanprice.text = mikanprice.ToString();

        switch (coinranapple)
        {
            case 1:
                
                apple[0].gameObject.SetActive(true);
                break;

            case 2:
                
                apple[1].gameObject.SetActive(true);
                break;

            case 3:
                
                apple[2].gameObject.SetActive(true);
                break;

            case 4:
                
                apple[3].gameObject.SetActive(true);
                break;

            case 5:
                
                apple[4].gameObject.SetActive(true);
                break;

            case 6:
                
                apple[5].gameObject.SetActive(true);
                break;

            case 7:
                
                apple[6].gameObject.SetActive(true);
                break;

            case 8:
                
                apple[7].gameObject.SetActive(true);
                break;

            case 9:
                
                apple[8].gameObject.SetActive(true);
                break;


        }

        switch (coinranmikan)
        {
            case 1:
                
                mikan[0].gameObject.SetActive(true);
                break;

            case 2:
                
                mikan[1].gameObject.SetActive(true);
                break;

            case 3:
                
                mikan[2].gameObject.SetActive(true);
                break;

            case 4:
                
                mikan[3].gameObject.SetActive(true);
                break;

            case 5:
                
                mikan[4].gameObject.SetActive(true);
                break;

            case 6:
                
                mikan[5].gameObject.SetActive(true);
                break;

            case 7:
                
                mikan[6].gameObject.SetActive(true);
                break;

            case 8:
                
                mikan[7].gameObject.SetActive(true);
                break;

            case 9:
                
                mikan[8].gameObject.SetActive(true);
                break;


        }

    }

    public void randomquest()
    {
        randomquestion = Random.Range(1, 6);

        if (randomquestion == 1)
        {
            calculatequestion.gameObject.SetActive(true);
            Debug.Log("stage1");
        }
        if(randomquestion == 2)
        {
            coinquestion.gameObject.SetActive(true);
            Debug.Log("stage2");
        }
        if(randomquestion == 3)
        {
            questionquestion.gameObject.SetActive(true);
            Debug.Log("stage3");
        }
        if(randomquestion == 4)
        {
            percentquestion.gameObject.SetActive(true);
            Debug.Log("stage4");
        }
        if(randomquestion == 5)
        {
            oboequestion.gameObject.SetActive(true);
            questionone.gameObject.SetActive(true);
            questiontwo.gameObject.SetActive(true);
            nokoritext.gameObject.SetActive(true);
            oboerutext.gameObject.SetActive(true);
            Debug.Log("stage5");
        }

    }

    public void randomcolor()
    {
        blue = Random.Range(3, 12);
        red = Random.Range(3, 12);
        questionrandomcolor = Random.Range(1, 3);


        bluetext.text = blue.ToString();
        redtext.text = red.ToString();

        if (questionrandomcolor == 1)
        {
            quesitoncolor.text = "青";
            quesitoncolor.color = new Color(0, 0, 255);
        }
        else
        {
            quesitoncolor.text = "赤";
            quesitoncolor.color = new Color(255, 0, 0);
        }

    }

    public void randomprice()
    {
        afterprice = Random.Range(1,11)*50;

        saleswitch = Random.Range(1, 5);
        pricepercentswitch = Random.Range(1, 5);

        switch (saleswitch)
        {
            case 1:
                
                sale = 90;
                break;

            case 2:
                
                sale = 75;
                break;

            case 3:
                
                sale = 50;
                break;

            case 4:
                
                sale = 80;
                break;
        }

        switch (pricepercentswitch)
        {
            case 1:
                
                pricepercent = 10;
                break;

            case 2:
                
                pricepercent = 20;
                break;

            case 3:
                
                pricepercent = 25;
                break;

            case 4:
                
                pricepercent = 50;
                break;
        }

        originapricefirst = afterprice * (100 / (100 - sale));
        originalprice = originapricefirst * (100 / pricepercent);
        

        percenttext.text = pricepercent.ToString();
        saletext.text = sale.ToString();
        pricetext.text = afterprice.ToString();


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

        if(timecheck < 3)
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
