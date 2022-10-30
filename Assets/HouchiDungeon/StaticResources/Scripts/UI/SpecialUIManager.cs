using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool toggle = true;
    public void SpecialOn()
    {
        if (toggle)
        {
            StaticValueManager.instance.isSpecial = true;
            toggle = false;
        }
        else
        {
            StaticValueManager.instance.isSpecial = false;
            toggle = true;
        }

    }
}
