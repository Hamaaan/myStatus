using UnityEngine;
using UnityEngine.UI; //Textを使用する為追加。
using System; //DateTimeを使用する為追加。

public class TimeText : MonoBehaviour
{
    //テキストUIをドラッグ&ドロップ
    [SerializeField] Text DateTimeText;

    //DateTimeを使うため変数を設定
    DateTime TodayNow;

    void Update()
    {
        //時間を取得
        TodayNow = DateTime.Now;

        //テキストUIに年・月・日・秒を表示させる
        DateTimeText.text = TodayNow.Year.ToString() + "/" + TodayNow.Month.ToString() + "/" + TodayNow.Day.ToString() + "/" + DateTime.Now.ToLongTimeString();
    }
}