using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMvcamManager : MonoBehaviour
{
    Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (StaticValueManager.instance.isDungeonClear)
        {
            _anim.SetBool("clear", true);
        }
    }
}