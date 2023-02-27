using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AutoRestart : MonoBehaviour
{
    [SerializeField] GameObject StaticCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((int)(Time.realtimeSinceStartup%10000) == 0) 
        {
            SceneManager.LoadScene("Opening 1");
        }

        //Debug.Log(Time.realtimeSinceStartup);

        if (StaticValueManager.instance.ActiveSceneName == "Opening 1"
            || StaticValueManager.instance.ActiveSceneName == "Intro")
        {
            StaticCanvas.SetActive(false);
        }
        else
        {
            StaticCanvas.SetActive(true);
        }
    }
}
