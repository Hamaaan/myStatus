using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.activeSceneChanged += ActiveSceneChanged;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ActiveSceneChanged(Scene thisScene, Scene nextScene)
    {
        if (SceneManager.GetActiveScene().name == "Home")
        {
            this.gameObject.SetActive(false);
            Debug.Log("wtf");
        }
    }
}
