using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    //public GameObject player;
    private Inventory inventory;
    public Item item;
    private ItemType thisType;
    public GameObject itemIcon;
    private int wishedSlot;
    private bool inPickupRange = false;
    
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        
        //Spoiler, find with tag  c'est dégueu, vivement le manager qui transmet le player

        //CHB:
        //Get item type and target correponding inventory slot
        thisType = item.WhatType();
        wishedSlot = (int)thisType;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            inPickupRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            inPickupRange = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && inPickupRange == true)
        {
            if (inventory.isFull[wishedSlot] == false)
            {
                inventory.isFull[wishedSlot] = true;
                Instantiate(itemIcon, inventory.slots[wishedSlot].transform, false);
                Destroy(gameObject);
            }
            else
            {
                //CHB:
                //Call destroying item currently held and spawning corresponding collectible
                inventory.slots[wishedSlot].GetComponent<Slot>().DropItem();
                Instantiate(itemIcon, inventory.slots[wishedSlot].transform, false);
                Destroy(gameObject);
            }

        }
    }
}
