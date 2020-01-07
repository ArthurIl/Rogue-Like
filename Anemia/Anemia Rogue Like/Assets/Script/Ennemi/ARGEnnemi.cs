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
    public GameObject explosionSplat;

    public GameObject souls;


    public void EnnemisTakeDamage(float amount)
    {
        ennemiHealth -= amount;
        ennemiCanMove = false;
        canShoot = false;
        StartCoroutine("CanMoveAgain");

    }
    public void Death()
    {
        if (ennemiHealth <= 0)
        {
            Instantiate(souls, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            Instantiate(explosionSplat, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    IEnumerator CanMoveAgain()
    {
        yield return new WaitForSeconds(2);
        ennemiCanMove = true;
    }
}
