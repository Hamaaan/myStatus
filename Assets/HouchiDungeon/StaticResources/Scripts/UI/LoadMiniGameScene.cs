using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMiniGameScene : MonoBehaviour
{
    public float AudioVolume = 1f;
    public string[] SceneName;

    StaticValueManager _svm;

    // Start is called before the first frame update
    void Start()
    {
        _svm = StaticValueManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = AudioVolume;
    }

    public void SceneChangeTo()
    {
        string minigame = SceneName[Random.Range(0, SceneName.Length)];
        _svm.PreMiniGameScene = minigame;
        SceneManager.LoadScene(minigame);
    }
}
