using ProjectJ40.Growth;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdultPhase : IState
{
    public GrowthStage Stage => GrowthStage.Adult;

    private readonly Player pj;
    private readonly StateMachine fsm;

    public AdultPhase(Player p, StateMachine fsm)
    {
        this.pj = p;
        this.fsm = fsm;
    }
    public void Enter()
    {
        Debug.Log("Fase adulto");
    }

    public void Execute()
    {
        Debug.Log("Siendo adulto");
    }

    public void Exit()
    {
        Debug.Log("Ya no es adulto");
    }
}
