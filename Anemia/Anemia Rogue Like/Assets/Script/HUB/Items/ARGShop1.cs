﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARGShop1 : MonoBehaviour
{
    public static ARGShop1 Instances { get; private set; }
    public int bloods;
    public int price;
    private int newBloods;
    public GameObject thisObject;
    public GameObject itemUnlocked;
    public GameObject itemUnlockedChest;
    private List<GameObject> thisList;
    private bool canBuy1;
    public GameObject priceHeader;
    // Start is called before the first frame update

    private void Awake()
    {
        if (Instances == null)
        {
            Instances = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canBuy1 == true && Input.GetButton("Pick"))
        {

            newBloods = bloods - price;
            GameManager.Instance.bloodCount = newBloods;
            thisObject.SetActive(false);
            GameManager.Instance.ItemList(itemUnlocked);
            GameManager.Instance.ItemListChest(itemUnlockedChest);
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bloods = GameManager.Instance.bloodCount;
        priceHeader.SetActive(true);
        if (bloods >= price)
        {
            canBuy1 = true;
        }
        else
        {
            canBuy1 = false;
        }


    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canBuy1 = false;
        priceHeader.SetActive(false);
    }
}