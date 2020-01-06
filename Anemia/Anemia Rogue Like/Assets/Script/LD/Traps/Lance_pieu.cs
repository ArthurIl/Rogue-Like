using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lance_pieu : MonoBehaviour
{
    protected float timeBtwShots;
    public float startTimeBtwShot;
    public GameObject projectile;
    private Animator animDroite;
    private Animator animGauche;

    private void Start()
    {
        animDroite = GetComponent<Animator>();
        animGauche = GetComponent<Animator>();
    }
    protected void Shoot()
    {
        if (timeBtwShots < +0)
        {
            animDroite.SetBool("isNoArrow", false);
            animDroite.SetBool("isShooting", true);
            Instantiate(projectile, transform.localPosition, transform.rotation);
            timeBtwShots = startTimeBtwShot;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
            animDroite.SetBool("isNoArrow", true);
        }
    }

    private void Update()
    {
        Shoot();
    }
}
