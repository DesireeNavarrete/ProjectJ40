using ProjectJ40.Growth;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeenPhase : IState
{
    public GrowthStage Stage => GrowthStage.Teen;

    private readonly Player pj;
    private readonly StateMachine fsm;

    public TeenPhase(Player p, StateMachine fsm)
    {
        this.pj = p;
        this.fsm = fsm;
    }
    public void Enter()
    {
        Debug.Log("Fase adolescente");

    }

    public void Execute()
    {
        Debug.Log("Siendo adolescente");
    }

    public void Exit()
    {
        Debug.Log("Ya no es adolescente");
    }

}
