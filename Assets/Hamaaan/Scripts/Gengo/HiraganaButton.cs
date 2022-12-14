using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HiraganaButton : MonoBehaviour
{
    Text text;
    [SerializeField] Text TargetText;


    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(ButtonMethod), 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnClick()
    {
        TargetText.text += text.text;
    }

    
    void ButtonMethod()
    {
        text = this.gameObject.GetComponentInChildren<Text>();
    }
}
