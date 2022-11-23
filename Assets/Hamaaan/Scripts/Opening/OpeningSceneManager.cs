using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpeningSceneManager : MonoBehaviour
{
    [SerializeField] public Text InputName;
    [SerializeField] public Text DisplayName;

    public static string UserName;

    [SerializeField] string SceneName;

 

    // Start is called before the first frame update
    void Start()
    {
        InputName = InputName.GetComponent<Text>();
        DisplayName = DisplayName.GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        DisplayName.text = InputName.text;
        UserName = InputName.text.ToString();
    }

    public void OnClick()
    {
        SceneManager.LoadScene(SceneName);
    }

    public static string GetUserName()
    {
        return UserName;
    }
}
