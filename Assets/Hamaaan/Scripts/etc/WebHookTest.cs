using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class WebHookTest : MonoBehaviour
{
    [SerializeField] string Webhook;

    [SerializeField] string contentText;

    [SerializeField] InputField InputField;

    private sealed class Data
    {
        public string content;
    }
    void Awake()
    {
        InputField = InputField.GetComponent<InputField>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        contentText = InputField.text;
    }

    public void WebHook()
    {
        StartCoroutine(Upload());
    }

    public void JsonUpload()
    {

        var url = Webhook;
        var data = new Data();

        data.content = contentText;
        
        var json = JsonUtility.ToJson(data);
        var postData = Encoding.UTF8.GetBytes(json);

        var request = new UnityWebRequest(url, UnityWebRequest.kHttpVerbPOST)
        {
            uploadHandler = new UploadHandlerRaw(postData),
            downloadHandler = new DownloadHandlerBuffer()
        };

        request.SetRequestHeader("Content-Type", "application/json");

        var operation = request.SendWebRequest();

        Debug.Log(json);
        
        operation.completed += _ =>
        {
            Debug.Log(operation.isDone);
            Debug.Log(operation.webRequest.downloadHandler.text);
            Debug.Log(operation.webRequest.isHttpError);
            Debug.Log(operation.webRequest.isNetworkError);
        };
        
    }

    IEnumerator Upload()
    {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormDataSection("field1=foo&field2=bar"));
        formData.Add(new MultipartFormFileSection("my file data", "myfile.txt"));

        UnityWebRequest www = UnityWebRequest.Post("http://www.my-server.com/myform", formData);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }
}
