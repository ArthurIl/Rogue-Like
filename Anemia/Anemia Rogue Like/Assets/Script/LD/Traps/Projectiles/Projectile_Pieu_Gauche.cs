using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Pieu_Gauche : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    public float damage;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<GameHandler>().TakeDamage(damage);
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }

    }
}