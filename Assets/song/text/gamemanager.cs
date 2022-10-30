using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour
{


    public float timer;
    public float loadtime;
    public float condition;

    public bool start= false;

    public Text[] clock;

    public Text button;
   
    public Text loadtimer;
    public Text conditioner;

    public Text timewatch;
    public Image confilmImage;

    public Image selectimageone;
    public Image selectimagetwo;
    public Image selectimagethree;

    public gamemanager timersave;


    public Sprite[] images;


    public List<float> worklist = new List<float>(); 

    public List<float> timelist = new List<float>();

    public List<int> conditionlist = new List<int>();

    public List<int> moodlist = new List<int>();




    // Start is called before the first frame update
    void Start()
    {
        // second = GetComponent<Text>();
        
        
       
    }

    // Update is called once per frame
    void Update()
    {
        watch();
        buttonpush();
        buttonstatus();
 
    }

    public void timestart()
    {
        if (!start)
        {
            start = true;
            
        }
           
        else if (start)
        {
            start = false;
            
        }
            
    }

    public void confilm()
    {
        if (!start)
            confilmImage.gameObject.SetActive(true);
    }

    public void timereset()
    {
        timer = 0;
        clock[0].text = "00";
        clock[1].text = "00";
        clock[2].text = "00";

    }


    public void watch()
    {
        if (start)
        {
            timer += Time.deltaTime;
            clock[0].text = ((int)timer / 3600).ToString();
            clock[1].text = ((int)timer / 60 % 60).ToString();
            clock[2].text = ((int)timer % 60).ToString();

        }
    }

   public void timesave()
    {
        PlayerPrefs.SetFloat("Time", timersave.timer);
        PlayerPrefs.Save();
        Debug.Log(timer);
        
        timelist.Add(timer);
    }

    // good 2f, soso 1f, bad 0f 

    public void conditionsogood()
    {
        //PlayerPrefs.SetInt("Condition", 1);
        PlayerPrefs.Save();
        conditionlist.Add(4);
        

    }


    public void conditiongood()
    {
        //PlayerPrefs.SetInt("Condition", 1);
        //PlayerPrefs.Save();
        conditionlist.Add(3);
        
        
    }


    public void conditionsoso()
    {
        //PlayerPrefs.SetInt("Condition", 2);
        //PlayerPrefs.Save();
        conditionlist.Add(2);
        
        
    }

    public void conditionbad()
    {
        //PlayerPrefs.SetInt("Condition", 3);
        //PlayerPrefs.Save();
        conditionlist.Add(1);
        
        
    }

    public void conditionsobad()
    {
        //PlayerPrefs.SetInt("Condition", 3);
        //PlayerPrefs.Save();
        conditionlist.Add(0);
        

    }

    public void moodsogood()
    {
        moodlist.Add(4);
        timeload();
        timereset();
    }

    public void moodgood()
    {
        moodlist.Add(3);
        timeload();
        timereset();
    }

    public void moodsoso()
    {
        moodlist.Add(2);
        timeload();
        timereset();
    }

    public void moodbad()
    {
        moodlist.Add(1);
        timeload();
        timereset();
    }

    public void moodsobad()
    {
        moodlist.Add(0);
        timeload();
        timereset();
    }



    public void timeload()
    {
        loadtime =PlayerPrefs.GetFloat("Time", timersave.timer);
        condition = PlayerPrefs.GetInt("Condition");

        loadtimer.text = loadtime.ToString();
        conditioner.text = condition.ToString();

        Debug.Log(loadtime);
    }


    void buttonpush()
    {
        if (start)
        {
            button.text = " ";
            timewatch.gameObject.SetActive(true);

        }
        if (!start)
        {
            button.text = "start";
            timewatch.gameObject.SetActive(false);

        }


    }


    public void workbutton()
    {
        worklist.Add(1);
    }

    public void trainbutton()
    {
        worklist.Add(2);
    }

    public void talkbutton()
    {
        worklist.Add(3);
    }

    public void hobbybutton()
    {
        worklist.Add(4);
    }

    public void sleepbutton()
    {
        worklist.Add(5);
    }


    void buttonstatus()
    {
        if(worklist.Count == 1)
        {
            selectimageone.sprite = images[(int)worklist[0]];
        }
        if(worklist.Count == 2)
        {
            selectimagetwo.sprite = images[(int)worklist[1]];
        }
        if (worklist.Count == 3)
        {
            selectimagethree.sprite = images[(int)worklist[2]];
        }

    }

    public void buttononeremove()
    {
        worklist[0] = 0;
        selectimageone.sprite = images[(int)worklist[0]];
    }

    public void buttontworemove()
    {
        worklist[1] = 0;
        selectimagetwo.sprite = images[(int)worklist[1]];
    }

    public void buttonthreeremove()
    {
        worklist[2] = 0;
        selectimagethree.sprite = images[(int)worklist[2]];
    }


}
