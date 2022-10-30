using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clear : MonoBehaviour
{
       public int ClearNumbers;
        [SerializeField]
         Text clearText;
         bool trigger = false ;


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
            }
    }
}

