using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Q3_5QuestStep : QuestStep
{
    public CanvasComponent canvasComp;
    ButtonControl butCtrlfeed;

    private void Start()
    {
        canvasComp = GameObject.Find("CanvasPrincipal").GetComponent<CanvasComponent>();
        butCtrlfeed = canvasComp.bricolajeBut.GetComponent<ButtonControl>();
    }
    //Controlar el boton de alimentar y luego FinishQuestStep()
    private void Update()
    {
        if (butCtrlfeed.buttonpressed)
        {
            print("bricolaje");
            FinishQuestStep();
        }
    }
}
