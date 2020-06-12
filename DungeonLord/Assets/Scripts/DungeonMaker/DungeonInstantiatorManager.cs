using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonInstantiatorManager : MonoBehaviour
{
    public RoomHandler roomHandler;
    // Start is called before the first frame update
    void Start()
    {
        GameObject room = roomHandler.getRandomRoom();
        Instantiate(room, transform.parent);

        room = roomHandler.getRandomRoom();
        Vector3 pos = transform.position;
        pos.x += 2;
        Instantiate(room, pos, Quaternion.identity);
    }

    
}
