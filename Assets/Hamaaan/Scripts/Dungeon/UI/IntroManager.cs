using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;


public class IntroManager : MonoBehaviour
{
    [SerializeField] string SceneName;
    VideoPlayer vp;
    // Start is called before the first frame update
    void Start()
    {
        vp = GetComponent<VideoPlayer>();
        vp.loopPointReached += LoopPointReached;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoopPointReached(VideoPlayer vp)
    {
        SceneManager.LoadScene(SceneName);
    }
}
