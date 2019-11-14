﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{


    private float damage = 10f;
    public float explosionTimer;

   void Start()
    {
        StartCoroutine("Destroy");
    }


    public void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<GameHandler>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
        

    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(explosionTimer);
        Destroy(this.gameObject);

    }
}

