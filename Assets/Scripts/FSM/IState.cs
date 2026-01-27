using ProjectJ40.Growth;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState 
{
    GrowthStage Stage { get; }

    void Enter();      // Al entrar en el estado
    void Execute();    // Lógica continua llamada desde Update()
    void Exit();       // Al salir del estado
}
