using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnPoint;
    public float damage;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<GameHandler>().TakeDamage(damage);
            player.transform.position = spawnPoint.transform.position;

        }
    }
}
