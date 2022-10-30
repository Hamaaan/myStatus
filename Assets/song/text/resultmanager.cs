using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resultmanager : MonoBehaviour
{
    [SerializeField]
    public Slider experience;

    public float max;
    public float currency;
    public float nowexp;

    public bool activecheck= false;

    public Button experiencebutton;

    public float elapsedTimeone = 0.0f;

    public float distance;
    public float distanceset;
    public Text distancetext;

    public float enemy;
    public float enemyset;
    public Text enemytext;


    public float plusexp;
    public float plusexpset;
    public Text plusexptext;

    // Start is called before the first frame update
    void Start()
    {
        experience.value = (float)currency / (float)max;
        distancetext.text = distance.ToString();
        enemytext.text = enemy.ToString();
        plusexptext.text = plusexp.ToString();
        OnAddScore();
        


    }

    // Update is called once per frame
    void Update()
    {
        if (elapsedTimeone > 3)
        {
            activecheck = true;
        }
            


        activebutton();
        //nowexp = (float)currency / (float)max;
    }

    public void exp()
    {

        
    }

    public void OnAddScore()
    {
        
        StartCoroutine(DistanceAnimation(distanceset, 3));
        StartCoroutine(EnemyAnimation(enemyset, 2));
        StartCoroutine(PlusexpAnimation(plusexpset, 3));
    }

    public void minusexp()
    {
        //experiencebutton.gameObject.SetActive(false);
        StartCoroutine(MinusexpAnimation(plusexpset, 2));
        StartCoroutine(expAnimation(plusexpset, 2));
        activecheck = false;


    }

    public void activebutton()
    {
        if (activecheck == true)
            experiencebutton.gameObject.SetActive(true);
        if (activecheck == false)
            experiencebutton.gameObject.SetActive(false);

    }

   
    IEnumerator DistanceAnimation(float addDistance, float time)
    {
        //前回のスコア
        float befor = distance;
        //今回のスコア
        float after = distance + addDistance;
        //得点加算
        distance += addDistance;
        //0fを経過時間にする
        float elapsedTime = 0.0f;

        //timeが０になるまでループさせる
        while (elapsedTime < time)
        {
            float rate = elapsedTime / time;
            // テキストの更新
            distancetext.text = (befor + (after - befor) * rate).ToString("f0");

            elapsedTime += Time.deltaTime;
            // 0.01秒待つ
            yield return new WaitForSeconds(0.01f);
        }
        // 最終的な着地のスコア
        distancetext.text = after.ToString();
    }

    IEnumerator EnemyAnimation(float addEnemy, float time)
    {
        //前回のスコア
        float befor = enemy;
        //今回のスコア
        float after = enemy + addEnemy;
        //得点加算
        enemy += addEnemy;
        //0fを経過時間にする
        float elapsedTime = 0.0f;

        //timeが０になるまでループさせる
        while (elapsedTime < time)
        {
            float rate = elapsedTime / time;
            // テキストの更新
            enemytext.text = (befor + (after - befor) * rate).ToString("f0");

            elapsedTime += Time.deltaTime;
            // 0.01秒待つ
            yield return new WaitForSeconds(0.01f);
        }
        // 最終的な着地のスコア
        enemytext.text = after.ToString();
    }

    IEnumerator PlusexpAnimation(float addplusexp, float time)
    {
        //前回のスコア
        float befor = plusexp;
        //今回のスコア
        float after = plusexp + addplusexp;
        //得点加算
        plusexp += addplusexp;
        //0fを経過時間にする
        

        //timeが０になるまでループさせる
        while (elapsedTimeone < time)
        {
            float rate = elapsedTimeone / time;
            // テキストの更新
            plusexptext.text = (befor + (after - befor) * rate).ToString("f0");

            elapsedTimeone += Time.deltaTime;
            // 0.01秒待つ
            yield return new WaitForSeconds(0.01f);
        }
        // 最終的な着地のスコア
        plusexptext.text = after.ToString();
    }

    IEnumerator MinusexpAnimation(float Minusexp, float time)
    {
        //前回のスコア
        float befor = plusexp;
        //今回のスコア
        float after = 0;
        //得点加算
        plusexp -= Minusexp;
        //0fを経過時間にする

        float elapsedTime = 0.0f;
        //timeが０になるまでループさせる
        while (elapsedTime < time)
        {
            float rate = elapsedTime / time;
            // テキストの更新
            plusexptext.text = (befor + (after - befor) * rate).ToString("f0");

            elapsedTime += Time.deltaTime;
            // 0.01秒待つ
            yield return new WaitForSeconds(0.01f);
        }
        // 最終的な着地のスコア
        plusexptext.text = "0";
    }

    IEnumerator expAnimation(float addexp, float time)
    {
        //前回のスコア
        float befor = currency;
        //今回のスコア
        float after = currency + addexp;

        
        //得点加算
        currency += addexp;
        //0fを経過時間にする
        
        float elapsedTime = 0.0f;
        //timeが０になるまでループさせる
        while (elapsedTime < time)
        {
            float rate = elapsedTime / time;
            // テキストの更新
            nowexp = (befor + (after - befor) * rate);
            experience.value = (float)nowexp / (float)max;
            if (experience.value > 1)
            {
                experience.value --;
            }
            elapsedTime += Time.deltaTime;
            // 0.01秒待つ
            yield return new WaitForSeconds(0.01f);
        }
        // 最終的な着地のスコア
        //plusexptext.text = after.ToString();
    }

}
