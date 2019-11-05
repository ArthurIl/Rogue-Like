﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARGDrainColliderScript : MonoBehaviour
{
    public bool canDrain;
    bool alreadyInList;
    public GameObject Player;
    public List<GameObject> ennemiesDrainables = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //Player.GetComponent<GameHandler>().drainDammage;
    }

    // Update is called once per frame
    void Update()
    {
        ennemiesDrainables.RemoveAll(list_item => list_item == null); ennemiesDrainables.RemoveAll(list_item => list_item == null);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ennemi")
        {
            canDrain = true;
            foreach (GameObject ennemi in ennemiesDrainables)
            {
                if (collision.gameObject == ennemi)
                {
                    alreadyInList = true;
                }                
            }
            if (!alreadyInList)
            {
                ennemiesDrainables.Add(collision.gameObject);
                alreadyInList = false;
            }
                


        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ennemi")
        {
            canDrain = false;
            
        }
    }
}