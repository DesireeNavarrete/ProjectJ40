using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Notifications : MonoBehaviour
{
    private Queue<string> notifications = new Queue<string>();

    public GameObject queueUI;
    public Text prefab;

    Text txt;

    public void AddCommand(string command)//añade elemento a la cola
    {
        notifications.Enqueue(command);
        txt = Instantiate(prefab, queueUI.transform);
        txt.text = command;
    }

    public void QuitarCommand()//ejecuta el elemento de la cola
    {
        if (notifications.Count == 0) return;//si no hay nada en la cola, se sale

        notifications.Dequeue();
    }
}
