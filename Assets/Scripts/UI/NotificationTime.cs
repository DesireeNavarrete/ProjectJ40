using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationTime : MonoBehaviour
{
    //contador de tiempo de 5s hacia abajo
    float cont;
    public Notifications notis;


    private void Start()
    {
        notis = GameObject.Find("Queue").GetComponent<Notifications>();
    }
    private void OnEnable()
    {
        cont = 5;
    }
    private void Update()
    {
        //print(cont);
        if (cont > 0)
        {
            cont -= Time.deltaTime;
        }

        if (cont <= 0)
        {
            cont = 0;
            Destroy(gameObject);
            notis.QuitarCommand();
        }
    }
}
