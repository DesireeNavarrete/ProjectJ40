using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class NeedsNotificatonBath : MonoBehaviour
{
    public Notifications notis;
    public int contador = 30;
    public float cont;
    public Image img;
    public bool timeOver = false;
    public StatsManager statsManager;
    public NeedsSystem needsSystem;

    private void Start()
    {
        notis = GameObject.Find("--Queue--").GetComponent<Notifications>();
        statsManager = GameObject.Find("--StatsManager--").GetComponent<StatsManager>();
        needsSystem = GameObject.Find("--Needs--").GetComponent<NeedsSystem>();

        img = gameObject.transform.GetChild(0).GetComponent<Image>();
        statsManager.hambreStat.Multiplier = 2;
        statsManager.sleepStat.Multiplier = .5f;
        statsManager.jugarStat.Multiplier = 1;

        //needsSystem.contadorCaca = 0;
        //needsSystem.contadorDucha = 0;
    }

    //10s en verde + 10s en naranja + 10s en rojo
    private void OnEnable()
    {
        cont = contador;
    }

    private void Update()
    {
        //empieza a contar
        if (cont > 0)
        {
            cont -= Time.deltaTime;
        }

        if (cont <= 20)
        {
            img.DOColor(Color.yellow, 20);
        }

        if (cont <= 10)
        {
            img.DOColor(Color.red, 10);
            gameObject.transform.DOShakePosition(1, 2);
        }

        if (cont <= 0)//al llegar a 0 los multiplicadores de los stats suben
        {
            cont = 0;
            statsManager.hambreStat.Multiplier = 5;
            statsManager.sleepStat.Multiplier = 5;
            statsManager.jugarStat.Multiplier = 5;
        }
    }
}
