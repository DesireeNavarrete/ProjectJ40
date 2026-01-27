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

    void Update()
    {
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

    }

}
