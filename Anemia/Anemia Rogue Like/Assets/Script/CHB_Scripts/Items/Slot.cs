using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    //public GameObject player;
    private Inventory inventory;
    public int i;
    
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        //Spoiler, find with tag  c'est dégueu, vivement le manager qui transmet le player

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount <= 0)
        {
            inventory.isFull[i] = false;
        }
    }

    public void DropItem()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<DropSpawn>().SpawnDroppedItem();
            GameObject.Destroy(child.gameObject);
        }
    }
}
