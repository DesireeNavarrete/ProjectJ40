using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Q1_2QuestStep : QuestStep
{
    public CanvasComponent canvasComp;
    ButtonControl butCtrlfeed;

    private void Start()
    {
        canvasComp = GameObject.Find("CanvasPrincipal").GetComponent<CanvasComponent>();
        butCtrlfeed = canvasComp.computerBut.GetComponent<ButtonControl>();
    }
    //Controlar el boton de alimentar y luego FinishQuestStep()
    private void Update()
    {
        if (butCtrlfeed.buttonpressed)
        {
            print("Playing");
            FinishQuestStep();
        }
    }
}
