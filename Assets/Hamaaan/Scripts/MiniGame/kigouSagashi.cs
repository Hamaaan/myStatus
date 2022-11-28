using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class kigouSagashi : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject[] KigouPrefab;

    [SerializeField] int GridAmount;

    [SerializeField] GameObject SagasuObject;

    [SerializeField] int TargetLength = 0;

    public Text count;

    public GameObject videoplay;
    public Button gohomebutton;
    public float gohomebuttontimer;
    public bool buttoncheck = false;


    public float counttime;

    public Text counttimetext;

    public float buffsannsuu;

    // Start is called before the first frame update
    void Start()
    {
        int TargetNumber = (int)Random.Range(0, KigouPrefab.Length);

        for (int i = 0; i < GridAmount; i++)
        {
            int InstanceRandom = (int)Random.Range(0, KigouPrefab.Length);
            GameObject Instance;
            Instance = Instantiate(KigouPrefab[InstanceRandom]);
            Instance.transform.parent = this.transform;
            Instance.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);

            if (InstanceRandom == TargetNumber)
            {
                Instance.tag = "KS_Target";
                TargetLength++;
            }
        }

        GameObject SagasuInstance;
        SagasuInstance = Instantiate(KigouPrefab[TargetNumber]);
        SagasuInstance.transform.position = SagasuObject.transform.position;
        SagasuInstance.transform.localScale = new Vector3(10f, 10f, 10f);
        SagasuInstance.transform.parent = SagasuObject.transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {

        }

        count.text = TargetLength.ToString();
        gohomebuttontimecheck();
        timer();
    }

    public void timer()
    {
        counttime += Time.deltaTime;
        counttimetext.text = counttime.ToString("f0");

    }


    public void OnPointerClick(PointerEventData pointerData)
    {
        if (pointerData.pointerCurrentRaycast.gameObject.CompareTag("KS_Target"))
        {
            pointerData.pointerCurrentRaycast.gameObject.tag = "Untagged";

            Image pointImage;
            pointImage = pointerData.pointerCurrentRaycast.gameObject.GetComponent<Image>();

            pointImage.color = new Color(0,0,0,0);

            TargetLength--;

            if (TargetLength < 1)
            {
                //SceneManager.LoadScene("IQ_KigouSagashi");
                videoplay.gameObject.SetActive(true);
                buttoncheck = true;
                buffsannsuu = Mathf.Round(25 / counttime * 10f) * 0.1f;
            }
        }
    }

    public void goHome()
    {
        SceneManager.LoadScene("Home");
    }

    public void gohomebuttontimecheck()
    {
        if (buttoncheck)
            gohomebuttontimer += Time.deltaTime;

        if (gohomebuttontimer > 3)
        {
            gohomebutton.interactable = true;
        }
        else
        {
            gohomebutton.interactable = false;
        }


    }

}
