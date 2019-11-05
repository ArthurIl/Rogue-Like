using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Pieu_Droit : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;

    private void Update()
    {

        transform.Translate(Vector2.right * speed* Time.deltaTime);
    }

    void OnCollisionEnter2D(Collider2D other)
    {
        GameObject Player = GameObject.Find("Player");
        GameHandler health = Player.GetComponent<GameHandler>();

        if (other.gameObject.tag == "Player")
        {
            health.Damage();
        }
        Destroy(gameObject);
    }
}
