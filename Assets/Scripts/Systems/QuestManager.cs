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

    // Update is called once per frame
    void Update()
    {
        if (BabyToTeen)
        {
            GrowthController.GrowthFSM.ChangeState(new TeenPhase(pj, GrowthController.GrowthFSM));


        }
    }
}
