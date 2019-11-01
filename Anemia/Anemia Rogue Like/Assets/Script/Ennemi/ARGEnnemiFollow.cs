using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARGEnnemiFollow : ARGEnnemi
{
    // Start is called before the first frame update
    void Start()
    {
        ennemiCanMove = true;
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
        Death();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {        
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<GameHandler>().TakeDamage(damage);
        }
           
    }

    public void Follow()
    {
        if (Vector2.Distance(transform.position, target.transform.position) > 0.15f && ennemiCanMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }



}
