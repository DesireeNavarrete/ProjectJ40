using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rooms : MonoBehaviour
{
    public int id { get; private set; }
    public string roomName { get; private set; }

    public Rooms(int id, string roomName)
    {
        this.id = id;
        this.roomName = roomName;
    }
}
