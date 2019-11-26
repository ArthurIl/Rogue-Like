using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peureux : ARGEnnemi
{
    public float retreatDistancePeureux;


    // Start is called before the first frame update
    void Start()
    {
        ennemiCanMove = true;
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Death();
        if (Vector2.Distance(transform.position, target.transform.position) < retreatDistancePeureux && ennemiCanMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, -speed * Time.deltaTime);
            canShoot = false;
        }
        else
        {
            transform.position = this.transform.position;
        }
    }
}
