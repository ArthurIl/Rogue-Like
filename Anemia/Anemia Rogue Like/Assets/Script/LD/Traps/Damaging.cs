﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damaging : GameHandler
{
    [SerializeField]
    private float damage = 1;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            health = health - damage;
        }
    }
}
