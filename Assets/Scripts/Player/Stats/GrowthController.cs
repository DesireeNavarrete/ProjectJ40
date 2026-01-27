using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrowthController : MonoBehaviour
{
    public static StateMachine GrowthFSM { get; private set; }
    public Player pj;
    void Awake()
    {
        GrowthFSM = new StateMachine();
        GrowthFSM.Initialize(new BabyPhase(pj, GrowthFSM));
    }

    void Update()
    {
        GrowthFSM.Update();
    }
}
