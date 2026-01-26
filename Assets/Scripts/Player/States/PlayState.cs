using UnityEngine;
using UnityEngine.UI;

public class PlayState : IState
{
    private readonly Player pj;
    private readonly StateMachine fsm;

    public float nivel = 100;

    public float multiplicador=2;
    CanvasComponent canvasComp;

    public PlayState(Player p, StateMachine fsm)
    {
        this.pj = p;
        this.fsm = fsm;
    }
    public void Enter()
    {
        DebugConsole.instance.Log("Jugar activado");
        canvasComp = GameObject.Find("CanvasPrincipal").GetComponent<CanvasComponent>(); 
    }

    public void Execute()
    {
        nivel = Mathf.Clamp(nivel, 0, 100);
        canvasComp.nivelSliderJugar.fillAmount = nivel / 100;
        if (nivel > 0 && nivel <= 100)
        {
            nivel -= multiplicador * Time.deltaTime;
        }
        if (nivel <= 25)
        {
            canvasComp.nivelSliderJugar.color = Color.red;

        }
        else
            canvasComp.nivelSliderJugar.color = Color.green;
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }

}
