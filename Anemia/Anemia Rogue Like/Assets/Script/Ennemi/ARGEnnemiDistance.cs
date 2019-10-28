using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARGEnnemiDistance : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private Transform player;

    private float timeBtwShots;
    public float startTimeBtwShot;

    public GameObject projectile;

    private bool canShoot;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
        Shoot();
    }

    void Follow()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            canShoot = false;


        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {

            transform.position = this.transform.position;
            canShoot = true;

        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
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
