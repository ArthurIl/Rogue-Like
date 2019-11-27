using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawn : MonoBehaviour
{
    public GameObject itemToSpawn;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //Spoiler, find with tag  c'est dégueu, vivement le manager qui transmet le player

    }

    public void SpawnDroppedItem()
    {
        Vector2 playerPos = new Vector2(player.position.x, player.position.y);
        Instantiate(itemToSpawn, playerPos, Quaternion.identity);
    }
}
