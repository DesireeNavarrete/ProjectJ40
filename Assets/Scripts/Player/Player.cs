using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectJ40.Growth;

public class Player : MonoBehaviour
{

    //[SerializeField] private GrowthController growthController;

    public GameObject cuerpoP;
    public CanvasComponent canvasComp;
    void Start()
    {

    }

    void Update()
    {
        //TODO: poner en el click de la tarta?para que no se haga en update
        switch (GrowthController.GrowthFSM.CurrentState)
        {
            case BabyPhase:
                cuerpoP.GetComponent<SpriteRenderer>().color = Color.yellow;
                break;
            case TeenPhase:
                cuerpoP.GetComponent<SpriteRenderer>().color = Color.blue;
                canvasComp.weldBut.gameObject.SetActive(true);//activamos el boton de soldar
                //entrada: amigos, bio y baloncesto
                canvasComp.baloncestoBut.gameObject.SetActive(true);//activamos el boton de bloncesto
                canvasComp.quedarBut.gameObject.SetActive(true);//activamos el boton de salir conamigos
                canvasComp.bioBut.gameObject.SetActive(true);//activamos el boton de bio
                break;
            case AdultPhase:
                cuerpoP.GetComponent<SpriteRenderer>().color = Color.red;
                //cocina: protes y cafe
                canvasComp.proteinBut.gameObject.SetActive(true);//activamos el boton de protes
                canvasComp.coffeBut.gameObject.SetActive(true);//activamos el boton de cafe
                //lab: bricolaje
                canvasComp.bricolajeBut.gameObject.SetActive(true);//activamos el boton de bricolaje
                //bath: movil + cagar
                //dormit: movil + cama
                //entrada: crossfit(mochila) 
                canvasComp.crossfitBut.gameObject.SetActive(true);//activamos el boton de crossfit
                break;
        }
    }
}
