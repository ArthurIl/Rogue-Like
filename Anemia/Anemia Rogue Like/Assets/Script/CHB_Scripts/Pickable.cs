using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    public GameObject player;
    private Inventory inventory;
    public Item item;
    public GameObject itemIcon;
    private int wishedSlot;
    private bool inPickupRange = false;
    private void Start()
    {
        inventory = player.GetComponent<Inventory>();
        wishedSlot = (int)item.type;
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
        if (Input.GetKeyDown(KeyCode.F) && inventory.isFull[wishedSlot] == false && inPickupRange == true)
        {
            inventory.isFull[wishedSlot] = true;
            Instantiate(itemIcon, inventory.slots[wishedSlot].transform, false);
            Destroy(gameObject);
        }
    }
}
