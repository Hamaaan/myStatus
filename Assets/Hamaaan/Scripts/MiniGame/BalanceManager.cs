using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BalanceManager : MonoBehaviour
{
    [SerializeField] HingeJoint2D joint;

    [SerializeField] bool isBalanced = false;

    JointAngleLimits2D defaultLimits;

    [SerializeField] Rigidbody2D TargetWeight;

    [SerializeField] Collider2D col;

    public int measureWeight = 0;
    public int targetWeight = 0;
    [SerializeField] Text TargetWeightText;

    public GameObject videoplay;

    public float clearopentimer;

    public Button gohomebutton;
    public float gohomebuttontimer;
    public bool buttoncheck = false;

    public float counttime;

    public Text counttimetext;


    public float buffomori;


    // Start is called before the first frame update
    void Start()
    {
        joint = joint.GetComponent<HingeJoint2D>();
        defaultLimits = joint.limits;

        TargetWeight = TargetWeight.GetComponent<Rigidbody2D>();
        TargetWeight.mass = (int)Random.Range(1, 6);
        targetWeight = (int)TargetWeight.mass;
        TargetWeightText = TargetWeightText.GetComponent<Text>();
        TargetWeightText.text = targetWeight.ToString();

        col = col.GetComponent<Collider2D>();
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


    // Update is called once per frame
    void Update()
    {
        timer();
        gohomebuttontimecheck();
        JointAngleLimits2D BalanceLimits = new JointAngleLimits2D();
        BalanceLimits.max = 0;
        BalanceLimits.min = 0;

        if(measureWeight == TargetWeight.mass)
        {
            isBalanced = true;
        }
        else
        {
            isBalanced = false;
        }

        if (isBalanced)
        {
            if (lerpTime < 0.5f)
            {
                lerpTime += Time.fixedDeltaTime * 0.2f;
            }
            joint.limits = LerpLimittsChange(lerpTime + 0.5f);

            //TargetWeightText.text = "クリア！！！";
            clearopentimer += Time.deltaTime;
            buffomori = Mathf.Round((7 / counttime) * 3 * 10f) * 0.1f;
            
            //videoplay.gameObject.SetActive(true);
        }
        else
        {
            joint.limits = defaultLimits;
            lerpTime = 0f;
            //TargetWeightText.text = targetWeight.ToString();
            TargetWeightText.text = "";

        }

        if (clearopentimer > 3f)
        {
            videoplay.gameObject.SetActive(true);
            buttoncheck = true;
        }
            
    }

    public void timer()
    {
        counttime += Time.deltaTime;
        counttimetext.text = counttime.ToString("f0");

    }

    public void gohome()
    {
        SceneManager.LoadScene("Home");
    }

    float lerpTime = 0f;

    JointAngleLimits2D LerpLimittsChange(float t)
    {
        JointAngleLimits2D lm = new JointAngleLimits2D();
        lm.max = Mathf.Lerp(defaultLimits.max, 0, t*t);
        lm.min = Mathf.Lerp(defaultLimits.min, 0, t*t);

        return lm;
    }


}
