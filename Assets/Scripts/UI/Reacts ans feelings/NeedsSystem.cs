using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class NeedsSystem : MonoBehaviour
{

    public List<NeedsSO> scriptables = new List<NeedsSO>();//lista de emociones de scriptables
    public StatsManager statsManager;
    public UIManager uiManager;
    public CanvasComponent canvasComp;
    public Notifications notis;

    public int contadorCaca = 0;
    public int contadorDucha = 0;

    //contador de ganas de hacer caca
    public void CacaContador()
    {
        if (contadorCaca == 2)
        {
            notis.AddNotificationNeeds("caca");
            contadorCaca = 0;
        }
        else
            contadorCaca++;
    }
    //contador de ir a la ducha 
    public void DuchaContador()
    {
        if (contadorDucha == 2)
        {
            notis.AddNotificationNeeds("ducha");
            contadorDucha = 0;
        }
        else
            contadorDucha++;
    }

    private void Start()
    {
        canvasComp.foodBut.onClick.AddListener(() => CacaContador());
        canvasComp.computerBut.onClick.AddListener(() => DuchaContador());
    }

    private void Update()
    {
        //acceder a stats
        //Debug.LogError(statsManager.sleepStat.Value);

        //sueño
        //if (Mathf.RoundToInt(statsManager.sleepStat.Value) == 98)
        //{
        //    notis.AddNotificationNeeds("sleep");
        //}

        //enfado, 3 stats por debajo del 25
        //if (Mathf.RoundToInt(statsManager.sleepStat.Value) < 95
        //    && Mathf.RoundToInt(statsManager.hambreStat.Value) < 95
        //    && Mathf.RoundToInt(statsManager.jugarStat.Value) < 95)
        //{
        //    notis.AddNotificationNeeds("enfado");//fuck lohace en bucle
        //    print("AAAAAA");
        //}

        //TODO: necesidad de ir al baño o ducharse, barra de tiempo? y cuando este a 50 o menos, mensaje por texto "Cuidado, javi necesita ir al baño"
    }
}
