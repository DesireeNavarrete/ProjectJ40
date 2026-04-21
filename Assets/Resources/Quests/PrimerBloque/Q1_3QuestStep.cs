using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Q1_3QuestStep : QuestStep
{
    public CanvasComponent canvasComp;
    ButtonControl butCtrlfeed;

    private void Start()
    {
        canvasComp = GameObject.Find("CanvasPrincipal").GetComponent<CanvasComponent>();
        butCtrlfeed = canvasComp.dormirBut.GetComponent<ButtonControl>();
    }
    //Controlar el boton de alimentar y luego FinishQuestStep()
    private void Update()
    {
        if (butCtrlfeed.buttonpressed)
        {
            print("Durmiendo");
            FinishQuestStep();
        }
    }
}
