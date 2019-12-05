﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARGLayerManager : MonoBehaviour
{
    private GameObject[] props;
    private SpriteRenderer playerSpr;
    private SpriteRenderer propsSpr;


    void Start()
    {
        props = GameObject.FindGameObjectsWithTag("Props");
        playerSpr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        LayerManaging();
    }

    private void LayerManaging()
    {
        if (props.Length != 0)
        {
            for (int i=0; i<props.Length; i++)
            {
                if (props[i].transform.position.y < transform.position.y)
                {
                    propsSpr = props[i].GetComponent<SpriteRenderer>();
                    propsSpr.sortingOrder = playerSpr.sortingOrder + 1; 
                }
                else 
                {
                    propsSpr = props[i].GetComponent<SpriteRenderer>();
                    propsSpr.sortingOrder = playerSpr.sortingOrder - 1;
                }
            }
        }
    }
}