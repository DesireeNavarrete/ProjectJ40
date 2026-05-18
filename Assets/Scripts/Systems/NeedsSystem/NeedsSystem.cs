using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
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
            if (!notis.notificationsNeeds.Contains("caca"))
            {
                notis.AddNotificationNeeds("caca");
                contadorCaca = 0;
            }
        }
        else
            contadorCaca++;
    }
    //contador de ir a la ducha 
    public void DuchaContador()
    {
        if (contadorDucha == 2)
        {
            if (!notis.notificationsNeeds.Contains("ducha"))
            {
                notis.AddNotificationNeeds("ducha");
                contadorDucha = 0;
            }
        }
        else
            contadorDucha++;
    }

    private void Start()
    {
        canvasComp.foodBut.onClick.AddListener(() => CacaContador());
        canvasComp.computerBut.onClick.AddListener(() => DuchaContador());
    }
}
