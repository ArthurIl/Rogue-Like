using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARGEnnemiDistance : ARGEnnemi
{
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShot;

    public GameObject projectile;

    private bool canShoot;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
        Shoot();
    }

    void Follow()
    {
        if (Vector2.Distance(transform.position, target.transform.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            canShoot = false;


        }
        else if (Vector2.Distance(transform.position, target.transform.position) < stoppingDistance && Vector2.Distance(transform.position, target.transform.position) > retreatDistance)
        {

            transform.position = this.transform.position;
            canShoot = true;

        }
        else if (Vector2.Distance(transform.position, target.transform.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, -speed * Time.deltaTime);
            canShoot = false;
        }
    }
    void Shoot()
    {
        if (timeBtwShots <+0 && canShoot == true)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShot;
        } else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
