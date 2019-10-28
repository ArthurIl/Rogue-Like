﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARGEnnemiFollow : MonoBehaviour
{
    public float speed;
    private GameObject target;
    float damage = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.transform.position) > 0.15f)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision");
        other.gameObject.GetComponent<GameHandler>().TakeDamage(damage);
                
    }
}
