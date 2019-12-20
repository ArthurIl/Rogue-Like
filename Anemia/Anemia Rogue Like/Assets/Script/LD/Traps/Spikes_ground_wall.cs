using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes_ground_wall : MonoBehaviour
{
    [SerializeField]
    private float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<GameHandler>().TakeDamage(damage); ;
        }
        else if(collision.gameObject.tag == "Ennemi")
        {

        }
    }
}
