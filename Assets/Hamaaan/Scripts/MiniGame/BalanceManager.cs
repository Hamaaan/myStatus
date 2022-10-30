using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    // Update is called once per frame
    void Update()
    {
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

            TargetWeightText.text = "クリア！！！";
        }
        else
        {
            joint.limits = defaultLimits;
            lerpTime = 0f;
            //TargetWeightText.text = targetWeight.ToString();
            TargetWeightText.text = "";

        }

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
