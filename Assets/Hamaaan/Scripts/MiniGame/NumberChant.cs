using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class NumberChant : MonoBehaviour
{
    private string NumbersRow;

    [SerializeField] Text Number_text;
    [SerializeField] Image circle;
    [SerializeField] Image cross;

    public ClickButtonManager ClickButton;

    private string InputNumbers;

    [SerializeField] Text TimerText;
    public float TotalTime;
    public int seconds;

    public int RightNumber;
    public int TotalNumber;

    public bool InputFinished;

    // Start is called before the first frame update
    void Start()
    {
       
        circle.enabled = false;
        cross.enabled = false;
        NumbersRow = ((int)Random.Range(1, 9)).ToString() + ((int)Random.Range(1, 9)).ToString() + ((int)Random.Range(1, 9)).ToString() + ((int)Random.Range(1, 9)).ToString();

        Number_text = Number_text.GetComponent<Text>();
        Number_text.text = NumbersRow;

        seconds = (int)TotalTime;

        //問題数正解数をロード
        RightNumber = PlayerPrefs.GetInt("RightNumber", 0);
        TotalNumber = PlayerPrefs.GetInt("TotalNumber", 0);
       
        InputFinished = false;

        
    }




    // Update is called once per frame
    void Update()
    {

        TotalTime -= Time.deltaTime;
        seconds = (int)TotalTime;
        TimerText.text = seconds.ToString();

        if(seconds == 0)
        {
            Number_text.enabled = false;
            TimerText.enabled = false;
        }

        if (ClickButton.count == 4) //4回入力が終わったら
        {
            //セーブ完了フラグ
            if (InputFinished == false)
            {
                InputNumbers = string.Join("", ClickButton.InputNumbers);
                TotalNumber++;

                //正誤判別
                if (NumbersRow == InputNumbers)
                {
                    Debug.Log("right");
                    circle.enabled = true;
                    RightNumber++;
                    PlayerPrefs.SetInt("RightNumber", RightNumber);
                }
                else
                {
                    cross.enabled = true;
                    Debug.Log("false");
                }

                //正解数、問題数をセーブ
                PlayerPrefs.SetInt("TotalNumber", TotalNumber);
                Debug.Log(TotalNumber);
            }
            //セーブ完了フラグ
            InputFinished = true;


            //シーンをロード
            Invoke("SceneReset", 2.0f);

            if (TotalNumber == 3)
            {
                //終了シーンをロード
                SceneManager.LoadScene("FinishScene");
            }


        }
    }
   
    private void SceneReset()
    {
        // 現在のSceneを取得
        Scene loadScene = SceneManager.GetActiveScene();
        // 現在のシーンを再読み込みする
        SceneManager.LoadScene(loadScene.name);
    }

}
