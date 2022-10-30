using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataSave : MonoBehaviour
{

    public GameObject Text_object = null; // Textオブジェクト

    public int timer = 0;
    public int timeStamp = 0;
    public string action = "";
    public string condition = "";
    public string mood = "";
    public string sticker = "";

    [SerializeField] Dropdown moodDropdown;

    void Start()
    {
        // スコアのロード
        moodDropdown = moodDropdown.GetComponent<Dropdown>();
    }
    // 削除時の処理
    void OnDestroy()
    {
        // スコアを保存
        PlayerPrefs.SetString("Mood", moodDropdown.captionText.text);
        PlayerPrefs.Save();
    }

    // 更新
    void Update()
    {
        // オブジェクトからTextコンポーネントを取得
        Text Text = Text_object.GetComponent<Text>();
        // テキストの表示を入れ替える
        Text.text = mood;
        mood = PlayerPrefs.GetString("Mood");
    }
}

