using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialManager : MonoBehaviour
{
    [SerializeField] GameObject Special;

    [SerializeField] GameObject[] Buff;

    [SerializeField] string[] MiniGame;

    StaticValueManager _svm;

    // Start is called before the first frame update
    void Start()
    {
        Special.SetActive(StaticValueManager.instance.isSpecial);
        _svm = StaticValueManager.instance;

        string preMiniGame = _svm.PreMiniGameScene;
        for (int i = 0; i < Buff.Length; i++)
        {
            if (preMiniGame == MiniGame[i])
            {
                Buff[i].SetActive(true);

                
                if (preMiniGame == "testcoin")
                {
                    _svm.PlayerHP *= 1.2f;
                }else if (preMiniGame == "testomori")
                {
                    //_svm.PlayerExp *= 1.2f;
                }
                


            }
            else
            {
                Buff[i].SetActive(false);
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
