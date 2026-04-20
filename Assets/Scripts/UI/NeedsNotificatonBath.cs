using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class NeedsNotificatonBath : MonoBehaviour
{
    public Notifications notis;
    public int contador=30;
    public float cont;
    public Image img;
    private void Start()
    {
        notis = GameObject.Find("--Queue--").GetComponent<Notifications>();
        img = gameObject.transform.GetChild(0).GetComponent<Image>();
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
            img.DOColor(Color.yellow, .5f);
        }

        if (cont <= 10)
        {
            img.DOColor(Color.red, .5f);
            gameObject.transform.DOShakePosition(1,1);
        }
    }
}
