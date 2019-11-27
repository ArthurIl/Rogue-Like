using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    private GameObject player;
    public GameObject entrance;
    public GameObject room;
    public GameObject spawnerEntrance;
    private RoomCreation spawnedGet;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        entrance = GameObject.FindGameObjectWithTag("Teleporter");
        spawnedGet = GameObject.FindGameObjectWithTag("Teleporter").GetComponent<RoomCreation>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        spawnedGet.spawned = false;
        spawnerEntrance = GameObject.FindGameObjectWithTag("SpawnerEntrance");
        entrance.transform.position = spawnerEntrance.transform.position;
        player.transform.position = entrance.transform.position;
        Destroy(spawnerEntrance.gameObject);
                
    }

}
