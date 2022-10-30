using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        /*
        // 現在のSceneを取得
        Scene loadScene = SceneManager.GetActiveScene();
        // 現在のシーンを再読み込みする
        SceneManager.LoadScene(loadScene.name);
        */
        //正誤判定をチェックする

        PlayerPrefs.DeleteAll();
        if (PlayerPrefs.HasKey("TotalNumber"))
        {
            Debug.Log("HasKey");
        }
        else
        {
            Debug.Log("NoKey");
        }
    }
}
