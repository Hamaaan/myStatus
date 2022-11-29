using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HiraganaInput : MonoBehaviour
{

    public ShuffleHiragana ShuffleHiraganaA;
    private GameObject GameObjectA;
    string A_text;
    [SerializeField]int N;

    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(InputMethod), 0.1f);

    }

    // Update is called once per frame
    void Update()
    {
    }

    void InputMethod()
    {
        ShuffleHiraganaA = ShuffleHiraganaA.GetComponent<ShuffleHiragana>();
        //gameObject.GetComponent<UnityEngine.UI.Text>().text = "Hello";
        //HiraganaUseListのｎ番目のゲームオブジェクト内のテキストを引っ張ってくる
        //HiraganaList[1]の要素をGameObjectとして呼び出すことに成功
            //var parent = this.transform;
            //Instantiate(ShuffleHiraganaA.HiraganaUseList[1],parent);
        GameObjectA = ShuffleHiraganaA.HiraganaUseList[N];
        A_text = GameObjectA.GetComponent<UnityEngine.UI.Text>().text;
        gameObject.GetComponent<UnityEngine.UI.Text>().text = A_text;
    }
}
