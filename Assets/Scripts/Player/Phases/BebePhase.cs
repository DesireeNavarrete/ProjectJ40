
using UnityEngine;

public class BebePhase : IState
{
    private readonly Player pj;
    private readonly StateMachine fsm;

    public BebePhase(Player p, StateMachine fsm)
    {
        this.pj = p;
        this.fsm = fsm;
    }
    public void Enter()
    {
        DebugConsole.instance.Log("Fase Bebe");

    }

    public void Execute()
    {
        DebugConsole.instance.Log("Siendo Bebe");
    }

    public void Exit()
    {
        DebugConsole.instance.Log("Ya no es Bebe");
    }


}
