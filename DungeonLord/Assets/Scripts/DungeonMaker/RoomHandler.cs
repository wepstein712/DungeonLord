using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// add more here when needed. expect this to handle giving information about rooms, picking a good sized one, holding references to the prefabs. 
// also used anyplace the actual tilemaps need to be used. all rooms that are in the game should be put and pulled from here.
public class RoomHandler : MonoBehaviour
{
    // list of all room prefabs
    public GameObject[] rooms;

    //get a random room from the list
    public GameObject getRandomRoom()
    {
        return rooms[Random.Range(0, rooms.Length)];
    }
}
