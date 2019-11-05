using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes_ground_wall : MonoBehaviour
{
    [SerializeField]
    private float damage = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject Player = GameObject.Find("Player");
        GameHandler health = Player.GetComponent<GameHandler>();
        if (collision.gameObject.tag == "Player")
        {
            health.Damage();
        }
    }
}
