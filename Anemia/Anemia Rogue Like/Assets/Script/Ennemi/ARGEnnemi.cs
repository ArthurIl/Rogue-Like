using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARGEnnemi : MonoBehaviour
{
    public bool ennemiCanMove;
    public bool canShoot;
    public float speed;
   [HideInInspector]
    public GameObject target;
    public float damage ;
    public float ennemiHealth;

    public void EnnemisTakeDamage(float amout)
    {
        ennemiHealth -= amout;
        ennemiCanMove = false;
        canShoot = false;

    }

    public void Death()
    {
        if (ennemiHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
