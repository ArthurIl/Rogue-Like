using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARGDrainColliderScript : MonoBehaviour
{
    public bool canDrain;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        //Player.GetComponent<GameHandler>().drainDammage;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ennemi")
        {
            canDrain = true;
            //collision.gameObject.GetComponent<GameHandler>().TakeDamage(damage);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ennemi")
        {
            canDrain = false;
            
        }
    }
}
