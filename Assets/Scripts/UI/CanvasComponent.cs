using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasComponent : MonoBehaviour
{
    public Image nivelSliderHambre;
    public Image nivelSliderSueño;
    public Image nivelSliderJugar;


    public Button nextRoom;
    public Button FoodBut;
    public Button PlayBut;
    public Button toiletBut;


    public Text currentRoomText;
    public Text textPrefabQuest;


    public GameObject cocinaCO;
    public GameObject labCO;
    public GameObject bathCO;
    public GameObject dormCO;
    public GameObject entradaCO;

    public GameObject questCompletePanel;
    public GameObject questPanel;
    public Transform questPanelIsntanciar;

    public Slider sliHambre;
    public Slider sliJugar;


}
