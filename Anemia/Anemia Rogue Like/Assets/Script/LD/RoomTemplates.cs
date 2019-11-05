using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] sudRooms;
    public GameObject[] nordRooms;
    public GameObject[] ouestRooms;
    public GameObject[] estRooms;
    public GameObject closedRooms;

    public List<GameObject> rooms;
    public float waitTime;
    private bool spawnedBoss;
    public GameObject boss;

    private void Update()
    {
        if(waitTime <= 0 && spawnedBoss == false)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (i == rooms.Count - 1)
                {
                    Instantiate(boss, rooms[i].transform.position, Quaternion.identity);
                    spawnedBoss = true;
                    
                }
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}
