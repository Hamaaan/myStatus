using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpeningSceneManager : MonoBehaviour
{
    [SerializeField] public Text InputName;
    [SerializeField] public Text DisplayName;

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
    }

    public void OnClick()
    {
        SceneManager.LoadScene(SceneName);
    }
}
