using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lance_pieu : MonoBehaviour
{
    protected float timeBtwShots;
    public float startTimeBtwShot;
    public GameObject projectile;
    protected void Shoot()
    {
        if (timeBtwShots < +0)
        {
            Instantiate(projectile, transform.position, transform.rotation);
            timeBtwShots = startTimeBtwShot;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    private void Update()
    {
        Shoot();
    }
}
