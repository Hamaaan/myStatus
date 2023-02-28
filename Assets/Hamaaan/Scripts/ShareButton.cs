using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class ShareButton : MonoBehaviour
{
    string imgPath;
    StaticValueManager _svm;

    private void Start()
    {
        SceneManager.activeSceneChanged += ActiveSceneChanged;
        _svm = StaticValueManager.instance;
    }

    void ActiveSceneChanged(Scene thisScene, Scene nextScene)
    {
        if (nextScene.name == "Home")
        {
            Debug.Log("BBBB");
        }
    }

    public void Take()
    {
        //参照したサイトはここでコルーチンを呼び出してるけど
        StartCoroutine(CaptureCoroutine());
        //リザルトになったタイミングとかでこのコルーチンを呼び出すようにすると良いかも？
        Debug.Log("Take()");

    }

    //シェアするときにこれを呼び出す
    public void Share()
    {
        //投稿
        PostResult();
        Debug.Log("Share()");

    }

    //スクショ保存のためのコルーチン
    public IEnumerator CaptureCoroutine()
    {
        const string fileName = "image.png";
        imgPath = Path.Combine(Application.persistentDataPath, fileName);

        //前回のデータを削除
        if (File.Exists(imgPath)) File.Delete(imgPath);

        //スクリーンショット撮影
        ScreenCapture.CaptureScreenshot(fileName);

        //撮影画像の保存が完了するまで待機
        while (true)
        {
            if (File.Exists(imgPath)) break;
            yield return null;
        }
    }

    //投稿する関数
    public void PostResult()
    {
        //ここでtweetTextに距離とかをStaticValueManagerから参照する？
        string tweetText = "今回の冒険で"+ _svm.PlayerDistance +"メートル進みました！";
        string tweetURL = "https://adaa.jp/ja/winners/winners2022.html";

        //このif文は付け足しました（要はスクショ撮る前に共有ボタンを押せるようにしたくない）
        if (File.Exists(imgPath))
        {
            //中身は一緒
            try
            {
                SocialConnector.SocialConnector.Share(tweetText, tweetURL, imgPath);
            }
            catch (System.Exception e)
            {
                Debug.LogError(e.Message);
            }
        }
    }
}
