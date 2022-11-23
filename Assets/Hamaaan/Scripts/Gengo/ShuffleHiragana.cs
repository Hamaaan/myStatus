using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleHiragana : MonoBehaviour
{
    public List<GameObject> HiraganaList;
    public List<GameObject> HiraganaUseList = new List<GameObject>();
    private GameObject randomObj;
    private int choiceNum;
 
    void Start()
    {
         for(int i=0; i<8; i++)
        {
            //HiraganaListの中からランダムで1つを選ぶ
            //randomObj = HiraganaList[Random.Range(0, HiraganaList.Count)];
            randomObj = HiraganaList[Random.Range(0, 1)];
            //選んだオブジェクトをuseListに追加
            HiraganaUseList.Add(randomObj);
            //選んだオブジェクトのリスト番号を取得
            choiceNum = HiraganaList.IndexOf(randomObj);
            //同じリスト番号をHiraganaListから削除
            HiraganaList.RemoveAt(choiceNum);
        }
    }
}