using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsView : MonoBehaviour
{
    private Stat stat;

    [SerializeField] private Image slider;
    [SerializeField] private Color normalColor = Color.green;
    [SerializeField] private Color warningColor = Color.red;
    [SerializeField] private float warningThreshold = 25f;

    public void SetStat(Stat newStat)
    {
        stat = newStat;
    }

    public static void SliderCooldownStats(Slider sli)
    {
        if (Stat.currentCooldown > 0)
        {
            sli.gameObject.SetActive(true);
        }
        if (Stat.currentCooldown <= 0)
        {
            sli.gameObject.SetActive(false);
        }

        sli.value = Stat.currentCooldown / 5;
    }


    void Update()
    {
        //Slider de los stats
        if (stat == null || slider == null) return;

        // Fill
        slider.fillAmount = stat.Value / 100f;

        // Color
        if (stat.Value <= warningThreshold)
        {
            slider.color = warningColor;
        }
        else
        {
            slider.color = normalColor;
        }


        //cooldown of a stat
        if (Stat.currentCooldown > 0)
        {
            Stat.currentCooldown -= Time.deltaTime;
            //print(stat.currentCooldown);    
        }

    }

}
