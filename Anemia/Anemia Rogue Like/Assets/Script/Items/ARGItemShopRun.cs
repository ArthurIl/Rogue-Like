using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARGItemShopRun : MonoBehaviour
{
    public int price;
    public GameObject itemGiven;
    private int souls;
    private Transform player;
    private bool canBuy;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Pick") && souls >= price && canBuy)
        {
            GameManager.Instance.soulsCount = souls - price;
            Vector2 playerPos = new Vector2(player.position.x, player.position.y);
            Instantiate(itemGiven, playerPos, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            souls = GameManager.Instance.soulsCount;
            canBuy = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canBuy = false;
        }
    }
}
