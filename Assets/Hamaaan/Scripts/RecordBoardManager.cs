using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordBoardManager : MonoBehaviour
{
    [SerializeField] Text DebugText;

    [SerializeField] Dropdown moodDropdown;
    [SerializeField] Dropdown actionDropdown;
    [SerializeField] Dropdown conditionDropdown;
    [SerializeField] Dropdown stickerDropdown;


    // Start is called before the first frame update
    void Start()
    {
        DebugText = DebugText.GetComponent<Text>();

        moodDropdown = moodDropdown.GetComponent<Dropdown>();
        actionDropdown = actionDropdown.GetComponent<Dropdown>();
        conditionDropdown = conditionDropdown.GetComponent<Dropdown>();
        stickerDropdown = stickerDropdown.GetComponent<Dropdown>();


    }

    // Update is called once per frame
    void Update()
    {

        DebugText.text = moodDropdown.captionText.text + "\n"
                            + actionDropdown.captionText.text + "\n"
                            + conditionDropdown.captionText.text + "\n"
                            + stickerDropdown.captionText.text + "\n";
        


    }
}
