using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageMaterialController : MonoBehaviour
{
    Image render;

    public float Hue = 0f;
    public float Satuation = 1f;
    public float Value = 1f;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        render.material.SetFloat("_Hue",Hue);
        render.material.SetFloat("_Sat", Satuation);
        render.material.SetFloat("_Val", Value);
    }

    public void HueController(float h)
    {
        Hue = h;
    }

    public void SatuationController(float s)
    {
        Satuation = s;
    }
    public void ValueController(float v)
    {
        Value = v;
    }
}
