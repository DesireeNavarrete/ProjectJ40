using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedQuestStep : QuestStep
{
    public CanvasComponent canvasComp;
    ButtonControl butCtrlfeed;

    private void Start()
    {
        canvasComp = GameObject.Find("CanvasPrincipal").GetComponent<CanvasComponent>();
        butCtrlfeed = canvasComp.FoodBut.GetComponent<ButtonControl>();
    }
    //Controlar el boton de alimentar y luego FinishQuestStep()
    private void Update()
    {
        if (butCtrlfeed.buttonpressed)
        {
            print("Feeding");
            FinishQuestStep();

            //TODO: advancetostage dependiendo del stage acutal? 
        }
    }
}
