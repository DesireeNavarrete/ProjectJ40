using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private IState currentState;
    public IState CurrentState
    {
        get { return currentState; }
    }

    public void Initialize(IState startingState)
    {
        currentState = startingState;
        currentState.Enter();
    }
    public void ChangeState(IState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
    public void Update()
    {
        currentState?.Execute();
    }
}
