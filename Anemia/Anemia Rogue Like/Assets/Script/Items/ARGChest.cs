using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARGChest : MonoBehaviour
{
    private int souls;
    private int price;
    private bool canBuy;
    private bool alreadySpawned;
    public Transform spawnPoint;
    public GameObject chestClose;
    public GameObject chestOpen;

    // Start is called before the first frame update
    void Start()
    {
        alreadySpawned = false;
        price = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Pick") && souls >= price && canBuy)
        {
            GameManager.Instance.soulsCount = souls - price;
            alreadySpawned = true;
            GameManager.Instance.SetItemChest(spawnPoint);
            chestClose.SetActive(false);
            chestOpen.SetActive(true);
            canBuy = false;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canBuy = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!alreadySpawned)
        {
            if (collision.tag == "Player")
            {
                souls = GameManager.Instance.soulsCount;
                canBuy = true;
            }
        }

    }
}


