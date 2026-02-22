using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsManager : MonoBehaviour
{

    public Rooms cocinaRoom;
    public Rooms labRoom;
    public Rooms currentRoom;

    public CanvasComponent canvasComp;
    public List<string> rooms;

    void Start()
    {
        cocinaRoom = new Rooms(1, "cocina");
        labRoom = new Rooms(2, "lab");

        currentRoom = cocinaRoom;
        //canvasComp.nextRoom.onClick.AddListener(() => UpdateCurrentRoom());

    }

    void Update()
    {

    }

    void CreateRoom(int id, string name)
    {

    }


    int i = 1;
    public void NextRoom()
    {

        foreach (var room in rooms)
        {
            if (canvasComp.currentRoomText.text == room)
            {
                i++;
                if (i > 2)
                {
                    i = 1;
                }
            }
        }

        switch (i)
        {
            case 1:
                print("Changing to cocina");
                currentRoom = cocinaRoom;
                canvasComp.cocinaCO.SetActive(true);
                canvasComp.labCO.SetActive(false);
                canvasComp.currentRoomText.text = "1";
                break;
            case 2:
                print("Changing to lab");
                currentRoom = labRoom;
                canvasComp.labCO.SetActive(true);
                canvasComp.cocinaCO.SetActive(false);
                canvasComp.currentRoomText.text = "2";
                break;
            default:
                break;
        }
    }


    public void PreviousRoom()
    {

        foreach (var room in rooms)
        {
            if (canvasComp.currentRoomText.text == room)
            {
                i--;
                if (i < 1)
                {
                    i = 1;
                }
            }


        }

        switch (i)
        {
            case 1:
                print("Changing to cocina");
                currentRoom = cocinaRoom;
                canvasComp.cocinaCO.SetActive(true);
                canvasComp.labCO.SetActive(false);
                canvasComp.currentRoomText.text = "1";
                break;
            case 2:
                print("Changing to lab");
                currentRoom = labRoom;
                canvasComp.labCO.SetActive(true);
                canvasComp.cocinaCO.SetActive(false);
                canvasComp.currentRoomText.text = "2";
                break;
            default:
                break;
        }
    }
}
