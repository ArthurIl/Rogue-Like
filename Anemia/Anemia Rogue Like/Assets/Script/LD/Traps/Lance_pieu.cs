using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lance_pieu : MonoBehaviour
{
    private float timeBtwShots;
    public float startTimeBtwShot;
    public Transform player;
    public GameObject projectile;
    public float lookSpeed;
    void Shoot()
    {
        if (timeBtwShots < +0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShot;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    private void LookAtTarget ()
    {
        // get a rotation that points Z axis forward, and the Y axis towards the target
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, (player.position - transform.position));

        // rotate toward the target rotation, never rotating farther than "lookSpeed" in one frame.
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, lookSpeed);
    }
    private void Update()
    {
        Shoot();
        LookAtTarget();
    }
}
