using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [SerializeField] bool isToggleOn = true; 

    bool toggle = true;
    public void SetTimeScale(float scale)
    {
        if (isToggleOn)
        {
            if (toggle)
            {
                Time.timeScale = scale;
                toggle = false;
            }
            else
            {
                Time.timeScale = 1;
                toggle = true;
            }
        }
        else
        {
            Time.timeScale = scale;
        }
        
    }
}
