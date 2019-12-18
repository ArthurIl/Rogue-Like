using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARGAltar : MonoBehaviour
{
    private float healthPlayer;
    private bool canGiveHealth;
    private int blood;
    private int newBlood;
    private int numberOfBlood;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        canGiveHealth = false;
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(numberOfBlood);
        if (Input.GetButton("Drain") && canGiveHealth)
        {
            canGiveHealth = false;
            blood = GameManager.Instance.bloodCount;
            numberOfBlood = (int)healthPlayer / 10;
            newBlood = blood + numberOfBlood;
            GameManager.Instance.bloodCount = newBlood;
            player.GetComponent<GameHandler>().health = 0.5f;
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canGiveHealth = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
                healthPlayer = collision.GetComponent<GameHandler>().health;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canGiveHealth = false;
        }
    }
}
