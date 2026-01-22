using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nivel : MonoBehaviour
{
    public float nivel = 100;

    public float multiplicador;

    public Image nivelSlider;


    void Update()
    {

        nivel = Mathf.Clamp(nivel, 0, 100);
        nivelSlider.fillAmount = nivel/100;
        if (nivel > 0 && nivel <= 100)
        {
            nivel -= multiplicador * Time.deltaTime;
        }
        if (nivel <= 25)
        {
            nivelSlider.color = Color.red;
            
        }else
            nivelSlider.color = Color.green;
    }
}
