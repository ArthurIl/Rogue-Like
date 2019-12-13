﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARGShop : MonoBehaviour
{
    public static ARGShop Instances { get; private set; }
    public int bloods;
    public int price;
    private int newBloods;
    public GameObject thisObject;
    public GameObject itemUnlocked;
    private List<GameObject> thisList;
    public bool canBuy;
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

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (canBuy == true && Input.GetButton("Drain"))
        {

            newBloods = bloods - price;
            GameManager.Instance.bloodCount = newBloods;
            Debug.Log(newBloods);
            thisObject.SetActive(false);
            GameManager.Instance.ItemList(itemUnlocked);
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bloods = GameManager.Instance.bloodCount;
        priceHeader.SetActive(true);

        if (bloods >= price)
        {
            canBuy = true;
        }
        else
        {
            canBuy = false;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        canBuy = false;
        priceHeader.SetActive(false);
    }
}