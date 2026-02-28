using ProjectJ40.Growth;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public bool BabyToTeen;

    [SerializeField] private GrowthController growthController;
    public Player pj;

    void Start()
    {

    }


    void Update()
    {
        if (BabyToTeen)
        {
            growthController.AdvanceToStage(GrowthStage.Teen);//cambiar al estapa de creciemiento dependiendo de las misiones
        }
    }
}
