using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Clear : MonoBehaviour
{
       public int ClearNumbers;
        [SerializeField]
         Text clearText;
         bool trigger = false ;

    public GameObject videoplay;
    public Button gohomebutton;
    public float gohomebuttontimer;
    public bool buttoncheck = false;

    public GameObject puzzlepiece;

    public float counttime;

   // public Text counttimetext;


    public float buffpuzzle;

    void Start()
       {
       clearText.enabled = false;
              }



       void Update()
       {
            if(trigger == false)
            {
                CheckClear();
            }
        gohomebuttontimecheck();
        timer();
       }

    public void timer()
    {
        counttime += Time.deltaTime;
     //   counttimetext.text = counttime.ToString("f0");

    }

    public void gohomebuttontimecheck()
    {
        if (buttoncheck)
            gohomebuttontimer += Time.deltaTime;

        if (gohomebuttontimer > 3)
        {
            gohomebutton.interactable = true;
        }
        else
        {
            gohomebutton.interactable = false;
        }


    }

    void CheckClear()
    {
        //if (ClearNumbers <16)
        //{
            //return;
        //}
        
 
        if (ClearNumbers == 16)
            { 
            clearText.enabled = true;
            Debug.Log("CLEAR!!って出したいけどなんかテキストが出ない");
            trigger = true;
            videoplay.gameObject.SetActive(true);
            buttoncheck = true;
            buffpuzzle = Mathf.Round((35 / counttime) * 3 * 10f) * 0.1f;
            puzzlepiece.gameObject.SetActive(false);
        }
    }

    public void goHome()
    {
        SceneManager.LoadScene("Home");
    }

}

