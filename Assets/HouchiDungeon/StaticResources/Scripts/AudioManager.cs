using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AudioManager : MonoBehaviour
{
    AudioSource _audio;
    public AudioClip[] SceneBGM;
    public string[] SceneName;
    public float[] SceneBGMVolume;

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.activeSceneChanged += ActiveSceneChanged;
        _audio = GetComponent<AudioSource>();

        BGMChanger(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ActiveSceneChanged(Scene thisScene, Scene nextScene)
    {
        //SceneBGM
        BGMChanger(nextScene.name);
        
    }

    void BGMChanger(string sceneName)
    {
        for (int i = 0; i < SceneBGM.Length; i++)
        {
            if (SceneName[i] == sceneName)
            {
                _audio.clip = SceneBGM[i];
                _audio.volume = SceneBGMVolume[i];
                _audio.Play();
            }
        }
    }
}
