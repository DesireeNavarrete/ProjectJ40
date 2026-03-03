using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedQuestStep : QuestStep
{
    public CanvasComponent canvasComp;


    private void Start()
    {
        canvasComp = GameObject.Find("CanvasPrincipal").GetComponent<CanvasComponent>();
    }
    //Controlar el boton de alimentar y luego FinishQuestStep()
    private void Update()
    {
        if (canvasComp.FoodBut.GetComponent<ButtonControl>().buttonpressed)
        {
            print("Feeding");
            FinishQuestStep();
        }
    }

}
