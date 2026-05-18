using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Notifications : MonoBehaviour
{
    public Queue<string> notificationsUI = new Queue<string>();

    public List<string> notificationsNeeds;

    public GameObject queueUI;
    public GameObject queueNeeds;

    public GameObject prefabNeeds;
    public Text prefab;

    Text txt;
    GameObject goNeeds;

    public NeedsSystem reacts;
    public CanvasComponent canvasComp;


    public Text txtLog;


    void UpdateQueue()
    {
        //txtLog.text = string.Empty;

        foreach (string command in notificationsUI)
        {
            txt.text += command;
        }
    }

    //Notificaciones de necesidades
    public void AddNotificationNeeds(string react)//añade elemento a la cola
    {
        if (react == "caca")
        {
            print(react);
            canvasComp.toiletBut.interactable = true;
        }
        if (react == "ducha")
        {
            print(react);
            canvasComp.showerBut.interactable = true;
        }
        foreach (var item in reacts.scriptables)
        {
            if (item.reaccion == react)
            {
                goNeeds = Instantiate(prefabNeeds, queueNeeds.transform);
                goNeeds.transform.GetChild(1).GetComponent<Image>().sprite = item.emoticono;
                goNeeds.transform.name = react;
                notificationsNeeds.Add(react);
                //notificationsNeeds.Enqueue(react);
                //UpdateQueue();
                
            }
        }
    }

    //public void QuitarNotificationNeeds()//ejecuta el elemento de la cola
    //{
    //    if (notificationsNeeds.Count == 0) return;//si no hay nada en la cola, se sale

    //    notificationsNeeds.Dequeue();
    //}

    //public void ColaNeedsComprobar()
    //{
    //    if (notificationsNeeds.Count > 0)
    //    {
    //        //QuitarNotificationNeeds();
    //        //destruir obj
    //        Destroy(goNeeds);
    //    }
    //}


    //Notificaciones de texto
    public void AddNotificationUI(string command)//añade elemento a la cola
    {
        notificationsUI.Enqueue(command);
        txt = Instantiate(prefab, queueUI.transform);
        txt.text = command;
    }

    public void QuitarNotificationUI()//ejecuta el elemento de la cola
    {
        if (notificationsUI.Count == 0) return;//si no hay nada en la cola, se sale

        notificationsUI.Dequeue();
    }
}
