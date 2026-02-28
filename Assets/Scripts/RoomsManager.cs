using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsManager : MonoBehaviour
{

    Rooms cocinaRoom, labRoom, bathRoom, dormRoom, entradaRoom;
    Rooms currentRoom;

    public CanvasComponent canvasComp;
    public List<string> rooms;
    public int i = 1;


    void Start()
    {
        cocinaRoom = new Rooms(1, "cocina");
        labRoom = new Rooms(2, "lab");
        bathRoom = new Rooms(3, "bath");
        dormRoom = new Rooms(4, "dorm");
        currentRoom = cocinaRoom;
        i = currentRoom.id;


        //canvasComp.nextRoom.onClick.AddListener(() => UpdateCurrentRoom());

    }

    void Update()
    {

    }

    void CreateRoom(int id, string name)
    {

    }


    public void NextRoom()
    {
        i++;
        if (i > rooms.Count)
        {
            i = 1;
        }

        ChangeRoom();
    }


    public void PreviousRoom()
    {
        i--;
        if (i < 1)
        {
            i = rooms.Count;
        }
        ChangeRoom();

    }


    public void ChangeRoom()
    {
        switch (i)
        {
            case 1:
                print("Changing to cocina");
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
                currentRoom = bathRoom;
                canvasComp.dormCO.SetActive(true);
                canvasComp.bathCO.SetActive(false);
                canvasComp.labCO.SetActive(false);
                canvasComp.cocinaCO.SetActive(false);
                canvasComp.entradaCO.SetActive(false);
                canvasComp.currentRoomText.text = "Dorm";
                break;
            case 5:
                print("Changing to entrada");
                currentRoom = bathRoom;
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
