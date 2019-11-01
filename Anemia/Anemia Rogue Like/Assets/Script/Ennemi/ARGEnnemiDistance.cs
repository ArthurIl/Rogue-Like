using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARGEnnemiDistance : ARGEnnemi
{
    public float shootDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShot;

    public GameObject projectile;


    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
        ennemiCanMove = true;
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
        Shoot();
        Death();
    }

    void Follow()
    {
        Debug.Log( target.transform.position);
        if (Vector2.Distance(transform.position, target.transform.position) > shootDistance && ennemiCanMove)
        {
            Debug.Log("Je ne suis pas en range");
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            canShoot = false;


        }
        else if (Vector2.Distance(transform.position, target.transform.position) < shootDistance && Vector2.Distance(transform.position, target.transform.position) > retreatDistance && ennemiCanMove)
        {
            Debug.Log("Je suis en range");
            transform.position = this.transform.position;
            canShoot = true;

        }
        else if (Vector2.Distance(transform.position, target.transform.position) < retreatDistance && ennemiCanMove)
        {
            Debug.Log("Je fuis");
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
