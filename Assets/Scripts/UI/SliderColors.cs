using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderColors : MonoBehaviour
{

    public Image img;
    public Color colorInit;
    public Color colorMid;
    public Color colorEnd;

    private Slider sli;

    void Start()
    {
        sli = GetComponent<Slider>();
        img.color = colorInit;

    }

    // Update is called once per frame
    void Update()
    {
        if (sli.value>=sli.maxValue/2)
        {
            img.color = colorMid;
        }
        else
            img.color = colorInit;


        if (sli.value >= sli.maxValue)
        {
            img.color = colorEnd;
        }
    }
}
