using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour
{
    [SerializeField] GameObject DungeonTimer;
    [SerializeField] GameObject RestTimer;
    [SerializeField] GameObject HomeDummyTimer;

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.activeSceneChanged += ActiveSceneChanged;
        TimerManagiment(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        if (StaticValueManager.instance.ActiveSceneName == "Dungeon001")
        {
            DungeonTimer.SetActive(true);
        }
        else
        {
            DungeonTimer.SetActive(false);
        }
        RestTimer.SetActive(StaticValueManager.instance.isRestTime);

        if (!StaticValueManager.instance.isRestTime && !StaticValueManager.instance.isTimerOn)
        {
            HomeDummyTimer.SetActive(true);
        }
        else
        {
            HomeDummyTimer.SetActive(false);
        }


    }

    void ActiveSceneChanged(Scene thisScene, Scene nextScene)
    {
        //SceneBGM
        TimerManagiment(nextScene.name);
    }

    void TimerManagiment(string sceneName)
    {
        if (sceneName == "Dungeon001")
        {
            //StaticValueManager.instance.isTimerOn = true;
        }
    }

    public void StopTimer()
    {
        StaticValueManager.instance.isTimerOn = false;
        if (StaticValueManager.instance.ActiveSceneName != "Home")
        {
            SceneManager.LoadScene("Home");
        }
    }
}
