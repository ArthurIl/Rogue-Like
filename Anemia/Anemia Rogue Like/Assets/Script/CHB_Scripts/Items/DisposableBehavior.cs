﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisposableBehavior : MonoBehaviour
{
    private GameHandler playerHandler;
    private float playerHealth;
    private float playerAttackDam;
    private int playerSouls;
    public Disposable myDisposable;
    void Start()
    {
        playerHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<GameHandler>();
        playerAttackDam = playerHandler.attackDammage;
        playerSouls = playerHandler.soulsCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (myDisposable.healthRefill > 0)
            {
                playerHandler.TakeDamage(0 - myDisposable.healthRefill);
                Debug.Log("Health refilled of:" + myDisposable.healthRefill);
            }
            else if (myDisposable.dammageBoost > 0)
            {
                playerAttackDam = myDisposable.HitMore(playerAttackDam);
            }
            else if (myDisposable.soulsAdd > 0)
            {
                playerSouls = myDisposable.GiveSouls(playerSouls);
            }

            Destroy(gameObject);
        }
    }
}
