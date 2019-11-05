using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes_ground_wall : MonoBehaviour
{
    [SerializeField]
    private float damage = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<GameHandler>().TakeDamage(damage); ;
        }
    }
}
