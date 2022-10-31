using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMiniGameScene : MonoBehaviour
{
    public float AudioVolume = 1f;
    public string[] SceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = AudioVolume;
    }

    public void SceneChangeTo()
    {
        SceneManager.LoadScene(SceneName[Random.Range(0, SceneName.Length)]);
    }
}
