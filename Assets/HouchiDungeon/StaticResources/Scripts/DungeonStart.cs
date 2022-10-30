using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonStart : MonoBehaviour
{
    float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDungeon()
    {
        Time.timeScale = 1f;
    }
}
