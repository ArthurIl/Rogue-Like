using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnPoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject Player = GameObject.Find("Player");
        GameHandler health = Player.GetComponent<GameHandler>();
        if (collision.gameObject.name == "Player")
        {
            health.Damage();
            player.transform.position = spawnPoint.transform.position;

        }
    }
}
