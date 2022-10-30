using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUIManager : MonoBehaviour
{
    [SerializeField] GameObject StaticCanvas;

    [SerializeField] GameObject FinishUI;


    // Start is called before the first frame update
    void Start()
    {
        SceneManager.activeSceneChanged += ActiveSceneChanged;
    }

    // Update is called once per frame
    void Update()
    {
        FinishUIManager();
    }

    void ActiveSceneChanged(Scene thisScene, Scene nextScene)
    {
        /*
        if (SceneManager.GetActiveScene().name == "Home")
        {
            FinishUI.SetActive(false);
        }
        */
    }

    void FinishUIManager()
    {
        if (SceneManager.GetActiveScene().name == "Home")
        {
            FinishUI.SetActive(false);
        }
        else if (SceneManager.GetActiveScene().name == "Dungeon001")
        {

        }

        if (StaticValueManager.instance.isDungeonClear)
        {
            FinishUI.SetActive(true);
        }
    }
}
