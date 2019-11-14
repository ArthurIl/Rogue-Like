using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawn : MonoBehaviour
{
    public GameObject itemToSpawn;
    public Transform player;
    
    public void SpawnDroppedItem()
    {
        Vector2 playerPos = new Vector2(player.position.x - 3, player.position.y - 3);
        Instantiate(itemToSpawn, playerPos, Quaternion.identity);
    }
}
