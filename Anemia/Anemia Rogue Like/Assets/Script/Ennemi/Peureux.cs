using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peureux : ARGEnnemi
{
    public float retreatDistancePeureux;
    private Vector2 direction;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        ennemiCanMove = true;
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        direction = (target.transform.position - transform.position).normalized;
        anim.SetFloat("PeureuxMoveX", direction.x);

        Death();

        if (Vector2.Distance(transform.position, target.transform.position) < retreatDistancePeureux && ennemiCanMove)
        {
            anim.SetBool("isMoving", true);
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, -speed * Time.deltaTime);
            canShoot = false;
        }
        else
        {
            anim.SetBool("isMoving", false);
            transform.position = this.transform.position;
        }
    }
}
