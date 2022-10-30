using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DistanceManager : MonoBehaviour
{
    Text text;
    GameObject player;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = (player.transform.position.x);
        if (distance<1000)
        {
            text.text = distance.ToString("F1");

        }
        else
        {
            text.text = ((int)distance).ToString();
        }
    }
}
