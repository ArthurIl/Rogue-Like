using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    private GameObject player;
    public GameObject entrance;
    public GameObject room;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        entrance = GameObject.FindGameObjectWithTag("Teleporter");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.transform.position = entrance.transform.position;
        room = GameObject.FindGameObjectWithTag("Rooms");
        Destroy(room.gameObject);
        GetComponent<RoomCreation>().spawned = false;

    }

}
