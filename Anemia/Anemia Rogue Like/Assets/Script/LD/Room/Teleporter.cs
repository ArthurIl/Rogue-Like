using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    private GameObject player;
    public GameObject entrance;
    public GameObject room;
 
    private RoomCreation spawnedGet;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        entrance = GameObject.FindGameObjectWithTag("Entrance");
        spawnedGet = GameObject.FindGameObjectWithTag("Entrance").GetComponent<RoomCreation>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        spawnedGet.spawned = false;
        entrance.transform.position = transform.position;
       
        
                
    }

}
