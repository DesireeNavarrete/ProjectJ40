using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Notifications : MonoBehaviour
{
    private Queue<string> notificationsUI = new Queue<string>();
    private Queue<string> notificationsNeeds = new Queue<string>();

    public GameObject queueUI;
    public GameObject queueNeeds;

    public Image prefabNeeds;
    public Text prefab;

    Text txt;
    Image goNeeds;

    public NeedsSystem reacts;
    public CanvasComponent canvasComp;

    //Notificaciones de necesidades
    public void AddNotificationNeeds(string react)//añade elemento a la cola
    {
        foreach (var item in reacts.scriptables)
        {
            if (item.reaccion == react)
            {
                //print("react");
                goNeeds = Instantiate(prefabNeeds, queueNeeds.transform);
                goNeeds.sprite = item.emoticono;
                notificationsNeeds.Enqueue(react);
            }
        }
    }

    public void QuitarNotificationNeeds()//ejecuta el elemento de la cola
    {
        if (notificationsNeeds.Count == 0) return;//si no hay nada en la cola, se sale

        notificationsNeeds.Dequeue();
    }


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
