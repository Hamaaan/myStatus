using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GengoRikaiManager : MonoBehaviour
{
    [SerializeField] string csvDataName;
    static TextAsset csvFile;
    static List<string[]> wordData = new List<string[]>();
    [SerializeField] Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = text.GetComponent<Text>();

        CsvReader();





        /*
        for (int i = 0; i < 200; i++)
        {
            Debug.Log(wordData[i][0]);

        }
        */
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CsvReader()
    {
        csvFile = Resources.Load("CSV/" + csvDataName) as TextAsset;
        StringReader reader = new StringReader(csvFile.text);
        while (reader.Peek() != -1)//最後まで読み込むと-1になる関数
        {
            string line = reader.ReadLine();//一行ずつ読み込み
            wordData.Add(line.Split(','));//,区切りでリストに追加していく
        }
    }

    public void CheckDatabase()
    {
        bool flag = false;
        for (int i = 0; i < wordData.Count; i++)
        {
            if (text.text == wordData[i][1])
            {
                flag = true;
            }
        }

        if (flag)
        {
            Debug.Log("True");
        }
    }
}
