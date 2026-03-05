using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectJ40.Growth;

public class Player : MonoBehaviour
{

    [SerializeField] private GrowthController growthController;

    public GameObject cuerpoP;
    void Start()
    {

    }

    void Update()
    {
        if (GrowthController.GrowthFSM.CurrentState.Stage == GrowthStage.Baby)
        {
            //print("Bebeeeeeeee");
            cuerpoP.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        if (GrowthController.GrowthFSM.CurrentState.Stage == GrowthStage.Teen)
        {
            print("Niñoooooo");
            cuerpoP.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        if (GrowthController.GrowthFSM.CurrentState.Stage == GrowthStage.Adult)
        {
            print("Niño mayooooor");
        }
    }
}
