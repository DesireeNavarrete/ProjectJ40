using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Q1_5QuestStep : QuestStep
{
    public CanvasComponent canvasComp;
    ButtonControl butCtrlfeed;
    public Notifications notis;
    private void Start()
    {
        canvasComp = GameObject.Find("CanvasPrincipal").GetComponent<CanvasComponent>();
        butCtrlfeed = canvasComp.showerBut.GetComponent<ButtonControl>();
        notis = GameObject.Find("--Queue--").GetComponent<Notifications>();
    }
    //Controlar el boton de alimentar y luego FinishQuestStep()
    private void Update()
    {
        if (notis.notificationsNeeds.Count > 0)
        {
            if (notis.notificationsNeeds.Contains("ducha"))
            {
                if (butCtrlfeed.buttonpressed)
                {
                    FinishQuestStep();
                }
            }
        }
    }
}
