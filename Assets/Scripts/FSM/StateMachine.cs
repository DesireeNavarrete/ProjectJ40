using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private IState currentState;

    private IState previousState;

    public IState CurrentState
    {
        get { return currentState; }
    }
    public IState PreviousState
    {
        get { return previousState; }
    }

    public void Initialize(IState startingState)
    {
        currentState = startingState;
        currentState.Enter();
    }
    public void ChangeState(IState newState)
    {
        if(currentState.Stage == newState.Stage)
        {
            return;
        }
        previousState = currentState;

        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
    public void Update()
    {
        currentState?.Execute();
    }
}
