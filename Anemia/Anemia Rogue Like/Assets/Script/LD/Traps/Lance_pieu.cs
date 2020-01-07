using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lance_pieu : MonoBehaviour
{
    protected float timeBtwShots;
    public float startTimeBtwShot;
    public GameObject projectile;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Shoot()
    {
        if (timeBtwShots < +0)
        {
            anim.SetBool("isShooting", true);
            anim.SetBool("isNoArrow", false);
            Instantiate(projectile, transform.position, transform.rotation);
            timeBtwShots = startTimeBtwShot;
        }
        else
        {
            anim.SetBool("isNoArrow", true);
            timeBtwShots -= Time.deltaTime;
        }
    }

    private void Update()
    {
        Shoot();
    }
}
