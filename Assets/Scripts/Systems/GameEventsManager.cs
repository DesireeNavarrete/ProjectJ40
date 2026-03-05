using System;
using UnityEngine;

public class GameEventsManager : MonoBehaviour
{
    public static GameEventsManager instance { get; private set; }

    public QuestEvents questEvents;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Hay mas de un GameEventsManager en la escena");
        }
        instance = this;

        //instanciar los events
        questEvents = new QuestEvents();
        //Debug.Log(questEvents);
    }
}
