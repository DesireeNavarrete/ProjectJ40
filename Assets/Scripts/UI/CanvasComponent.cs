using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasComponent : MonoBehaviour
{
    [Header("Sliders stats")]
    public Image nivelSliderHambre;
    public Image nivelSliderSueño;
    public Image nivelSliderJugar;

    [Header("Fondo room")]
    public Image fondoHabitaciones;

    [Header("Botones")]
    public Button nextRoom;

    public Button foodBut;
    public Button computerBut;
    public Button weldBut;
    public Button toiletBut;
    public Button showerBut;
    public Button dormirBut;

    public Button coffeBut;
    public Button proteinBut;
    public Button bricolajeBut;
    public Button crossfitBut;
    public Button bioBut;
    public Button baloncestoBut;
    public Button quedarBut;

    public Button cumpleBut;

    public Button seguimientoQuests;




    [Header("Texts")]
    public Text currentRoomText;
    public Text textPrefabQuest;


    [Header("GO rooms")]
    public GameObject cocinaCO;
    public GameObject labCO;
    public GameObject bathCO;
    public GameObject dormCO;
    public GameObject entradaCO;

    public GameObject questCompletePanel;
    public GameObject questPanel;
    public Transform questPanelIsntanciar;
    
    public GameObject growingPanel;

    [Header("Cooldown")]
    public Slider sliCooldown;
    
    [Header("Experiencia")]
    public Slider sliExp;

    [Header("Reacts")]
    public GameObject emocionPanel;
    public Image emocion;

    [Header("Canvas")]
    public GameObject canvasGame;
    public GameObject canvasDead;
    public GameObject canvasDeadPanel;
    public GameObject canvasDeadPanelInicio;


}
