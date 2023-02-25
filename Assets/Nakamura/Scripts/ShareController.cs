using UnityEngine;
using System.IO;
using System.Collections;

public class ShareController : MonoBehaviour
{
    string imgPath;

    //シェアするときにこれを呼び出す
    public void Share()
    {
        //参照したサイトはここでコルーチンを呼び出してるけど
        //StartCoroutine(CaptureCoroutine());
        //リザルトになったタイミングとかでこのコルーチンを呼び出すようにすると良いかも？
        
        //投稿
        PostResult();
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
        string tweetText = "test";
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
