using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARGItemShopSwapwn : MonoBehaviour
{
    private GameObject items;
    public Transform spawnPoint;
    private bool alreadySpawned;

    // Start is called before the first frame update
    void Awake()
    {
        spawnPoint = this.gameObject.transform;
        alreadySpawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!alreadySpawned)
        {
            if (collision.gameObject.tag == "Player")
            {
                GameManager.Instance.SetItem(spawnPoint);
                alreadySpawned = true;
            }
        }

    }
}
