using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialManager : MonoBehaviour
{
    [SerializeField] GameObject Special;
    // Start is called before the first frame update
    void Start()
    {
        Special.SetActive(StaticValueManager.instance.isSpecial);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
