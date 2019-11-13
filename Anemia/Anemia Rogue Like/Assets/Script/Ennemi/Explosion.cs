using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    private float damage = 10f;
    // Start is called before the first frame update
    public void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Debug.Log("le joueur est la");
            collider.gameObject.GetComponent<GameHandler>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
        else 
        {
            Destroy(this.gameObject);
        }
        

    }
}

