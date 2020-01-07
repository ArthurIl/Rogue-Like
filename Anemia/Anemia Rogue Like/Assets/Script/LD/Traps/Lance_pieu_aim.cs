using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lance_pieu_aim : MonoBehaviour
{
    GameObject player;
    public float lookSpeed;
    public float timeBtwShots;
    public float startTimeBtwShot;
    public GameObject projectile;



    private void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void LookAtTarget()
    {
        // get a rotation that points Z axis forward, and the Y axis towards the target
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, (player.transform.position - transform.position));

        // rotate toward the target rotation, never rotating farther than "lookSpeed" in one frame.
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, lookSpeed);
    }
    private void Shoot()
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
            LookAtTarget();
        }
}
