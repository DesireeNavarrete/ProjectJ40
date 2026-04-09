using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsManager : MonoBehaviour
{
    [Header("Rooms")]
    public static Rooms cocinaRoom, labRoom, bathRoom, dormRoom, entradaRoom;
    Rooms currentRoom;

    [Header("Rooms parameters")]
    public static List<string> roomsList= new List<string>();
    int contadorRoom = 1;

    [Header("Color fondo rooms")]
    public Color cocinaColor;
    public Color labColor;
    public Color bathColor;
    public Color dormColor;
    public Color entradaColor;

    public CanvasComponent canvasComp;

    void Start()
    {
        //creamos las habitaciones default
        cocinaRoom = new Rooms(1, "cocina");
        labRoom = new Rooms(2, "lab");
        bathRoom = new Rooms(3, "bath");
        dormRoom = new Rooms(4, "dorm");
        currentRoom = cocinaRoom;
        contadorRoom = currentRoom.id;

        roomsList.Clear();
        roomsList.Add("cocina");
        roomsList.Add("lab");
        roomsList.Add("bath");
        roomsList.Add("dorm");
       

        //canvasComp.nextRoom.onClick.AddListener(() => UpdateCurrentRoom());

    }

    void Update()
    {
        print(roomsList.Count);
        foreach (var item in roomsList)
        {
            print(item);
        }
    }

    //Constructor para crear una habitacion en runtime, ej: cambio de fases
    public static void CreateRoom(int id, string name, Rooms room)
    {
        room = new Rooms(id, name);
        roomsList.Add(name);
    }

    //Con la lista de habitaciones como referencia, sumamos 1 cada vez que se clique en la flecha
    public void NextRoom()
    {
        contadorRoom++;
        if (contadorRoom > roomsList.Count)
        {
            contadorRoom = 1;
        }

        ChangeRoom();
    }


    public void PreviousRoom()
    {
        contadorRoom--;
        if (contadorRoom < 1)
        {
            contadorRoom = roomsList.Count;
        }
        ChangeRoom();

    }

    //activaciones y desactivaciones de los elementos del canvas para cada habitacion
    public void ChangeRoom()
    {
        switch (contadorRoom)
        {
            case 1:
                print("Changing to cocina");
                canvasComp.fondoHabitaciones.color = cocinaColor;
                currentRoom = cocinaRoom;
                canvasComp.cocinaCO.SetActive(true);
                canvasComp.labCO.SetActive(false);
                canvasComp.bathCO.SetActive(false);
                canvasComp.dormCO.SetActive(false);
                canvasComp.entradaCO.SetActive(false);
                canvasComp.currentRoomText.text = "Cocina";
                break;
            case 2:
                print("Changing to lab");
                canvasComp.fondoHabitaciones.color = labColor;
                currentRoom = labRoom;
                canvasComp.labCO.SetActive(true);
                canvasComp.cocinaCO.SetActive(false);
                canvasComp.bathCO.SetActive(false);
                canvasComp.dormCO.SetActive(false);
                canvasComp.entradaCO.SetActive(false);
                canvasComp.currentRoomText.text = "Lab";
                break;
            case 3:
                print("Changing to bath");
                canvasComp.fondoHabitaciones.color = bathColor;
                currentRoom = bathRoom;
                canvasComp.bathCO.SetActive(true);
                canvasComp.labCO.SetActive(false);
                canvasComp.cocinaCO.SetActive(false);
                canvasComp.dormCO.SetActive(false);
                canvasComp.entradaCO.SetActive(false);
                canvasComp.currentRoomText.text = "Bath";
                break;
            case 4:
                print("Changing to dorm");
                canvasComp.fondoHabitaciones.color = dormColor;
                currentRoom = dormRoom;
                canvasComp.dormCO.SetActive(true);
                canvasComp.bathCO.SetActive(false);
                canvasComp.labCO.SetActive(false);
                canvasComp.cocinaCO.SetActive(false);
                canvasComp.entradaCO.SetActive(false);
                canvasComp.currentRoomText.text = "Dorm";
                break;
            case 5:
                print("Changing to entrada");
                canvasComp.fondoHabitaciones.color = entradaColor;
                currentRoom = entradaRoom;
                canvasComp.entradaCO.SetActive(true);
                canvasComp.dormCO.SetActive(false);
                canvasComp.bathCO.SetActive(false);
                canvasComp.labCO.SetActive(false);
                canvasComp.cocinaCO.SetActive(false);
                canvasComp.currentRoomText.text = "Entrada";
                break;
            default:
                break;
        }
    }
}
