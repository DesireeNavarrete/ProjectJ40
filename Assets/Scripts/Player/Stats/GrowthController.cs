using ProjectJ40.Growth;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrowthController : MonoBehaviour
{
    public static StateMachine GrowthFSM { get; private set; }//maquina de estados para las fases
    public static Player pj;
    void Awake()
    {
        GrowthFSM = new StateMachine();
        GrowthFSM.Initialize(new BabyPhase(pj, GrowthFSM));//empezamos en la fase de bebe
        pj = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        GrowthFSM.Update();
        //print(GrowthFSM.CurrentState);
    }

    //funcion para cambiar de fase desde cualquier sitio
    public static void AdvanceToStage(GrowthStage newStage)
    {
        switch (newStage)
        {
            case GrowthStage.Teen://cambio de etapa, añadir diferentes stats + quests
                GrowthFSM.ChangeState(new TeenPhase(pj, GrowthFSM));
                break;

            case GrowthStage.Adult:
                GrowthFSM.ChangeState(new AdultPhase(pj, GrowthFSM));
                break;
        }
    }

}
