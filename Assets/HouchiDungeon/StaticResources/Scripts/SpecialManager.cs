using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialManager : MonoBehaviour
{
    [SerializeField] GameObject Special;

    [SerializeField] GameObject Fire;
    [SerializeField] GameObject Leaf;
    [SerializeField] GameObject Water;
    [SerializeField] GameObject Cray;
    [SerializeField] GameObject Gold;

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
