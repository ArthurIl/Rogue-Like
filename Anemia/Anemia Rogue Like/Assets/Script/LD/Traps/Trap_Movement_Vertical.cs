using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Movement_Vertical : MonoBehaviour
{
    [SerializeField]
    private float damage = 0.5f;
    [SerializeField]
    private float speed = 1f;
    private float waiting = 1f;
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject Player = GameObject.Find("Player");
        GameHandler health = Player.GetComponent<GameHandler>();

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<GameHandler>().TakeDamage(damage);
        }
        speed = -speed;
    }
}
