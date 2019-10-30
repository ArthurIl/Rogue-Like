using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARGEnnemi : MonoBehaviour
{
    public float speed;
    public GameObject target;
    public float damage = 0.05f;
    [SerializeField]
    protected float ennemiHealth = 1;


    public void EnnemisTakeDamage(float amout)
    {
        ennemiHealth -= amout;
    }

    public void Death()
    {
        if (ennemiHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
