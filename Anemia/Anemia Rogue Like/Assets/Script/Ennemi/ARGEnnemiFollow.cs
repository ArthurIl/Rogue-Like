using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARGEnnemiFollow : ARGEnnemi
{

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");//ARG ALED
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.transform.position) > 0.15f)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
        Death();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {        
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<GameHandler>().TakeDamage(damage);
        }
           
    }


}
