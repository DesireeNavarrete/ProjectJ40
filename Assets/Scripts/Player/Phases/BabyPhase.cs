
using ProjectJ40.Growth;
using UnityEngine;

public class BabyPhase : IState
{
    public GrowthStage Stage => GrowthStage.Baby;

    private readonly Player pj;
    private readonly StateMachine fsm;

    public BabyPhase(Player p, StateMachine fsm)
    {
        this.pj = p;
        this.fsm = fsm;
    }
    public void Enter()
    {
        //Debug.Log("Fase Bebe");
    }

    public void Execute()
    {
        //Debug.Log("Siendo Bebe");
    }

    public void Exit()
    {
        //Debug.Log("Ya no es Bebe");
    }


}
