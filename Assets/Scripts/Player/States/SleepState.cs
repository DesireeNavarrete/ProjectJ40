using UnityEngine;
using UnityEngine.UI;

public class SleepState : IState
{
    private readonly Player pj;
    private readonly StateMachine fsm;

    public float nivel = 100;

    public float multiplicador=1;
    CanvasComponent canvasComp;

    public SleepState(Player p, StateMachine fsm)
    {
        this.pj = p;
        this.fsm = fsm;
    }
    public void Enter()
    {
        DebugConsole.instance.Log("Sueño activado");
        canvasComp = GameObject.Find("CanvasPrincipal").GetComponent<CanvasComponent>(); 
    }

    public void Execute()
    {
        nivel = Mathf.Clamp(nivel, 0, 100);
        canvasComp.nivelSliderSueño.fillAmount = nivel / 100;
        if (nivel > 0 && nivel <= 100)
        {
            nivel -= multiplicador * Time.deltaTime;
        }
        if (nivel <= 25)
        {
            canvasComp.nivelSliderSueño.color = Color.red;

        }
        else
            canvasComp.nivelSliderSueño.color = Color.green;
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }

}
