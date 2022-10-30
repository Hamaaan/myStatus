using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDataManager : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [SerializeField] List<string> mood_id = new List<string>();
    [SerializeField] List<string> action_id = new List<string>();
    [SerializeField] List<string> condition_id = new List<string>();
    [SerializeField] List<string> sticker_id = new List<string>();

    public string[][] DataConverter(string mood, string action, string condition, string sticker)
    {
        for (int i = 0; i < mood_id.Count; i++)
        {
            if (mood == mood_id[i])
            {
                mood = mood_id[i];
            }
        }

        for (int i = 0; i < action_id.Count; i++)
        {
            if (action == action_id[i])
            {
                action = action_id[i];
            }
        }

        for (int i = 0; i < condition_id.Count; i++)
        {
            if (condition == condition_id[i])
            {
                condition = condition_id[i];
            }
        }

        for (int i = 0; i < sticker_id.Count; i++)
        {
            if (sticker == sticker_id[i])
            {
                sticker = sticker_id[i];
            }
        }

        string[][] DataConverter = new string[4][];
        


        return DataConverter;
    }

        /*
        mood

        00 none
        01 good
        02 normal
        03 bad

        action

        00 none
        01 exercise
        02 communication
        03 work
        04 sleep
        05 outdoor
        06 hobby

        condition

        00 none
        01 efficient
        02 inefficient
        03 work
        04 sleep
        
        sticker

        00 none
        01 cafein
        02 carbohydrate
        03 alcohol
        04 tobacco

        */
}
