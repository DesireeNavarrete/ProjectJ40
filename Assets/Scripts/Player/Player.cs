using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private StateMachine fsm;
    void Start()
    {
        fsm= new StateMachine();
        //Iniciamos en bebe
        fsm.Initialize(new BebePhase(this, fsm));
    }

    // Update is called once per frame
    void Update()
    {
        fsm.Update();
    }
}
