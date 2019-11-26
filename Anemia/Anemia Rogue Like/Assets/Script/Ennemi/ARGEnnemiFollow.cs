using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARGEnnemiFollow : ARGEnnemi
{
    private bool canAttack;
    public Collider2D playerCollider;
    
    void Start()
    {
        ennemiCanMove = true;
        target = GameObject.FindGameObjectWithTag("Player");
        canAttack = false;
        playerCollider = target.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
        Death();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && canAttack == false)
        {
            StartCoroutine("Attack");
        }
    }

    private void OnTriggerStay2D(Collider2D collid)
    {
        if (canAttack == true && collid.gameObject.CompareTag("Player"))
        {
            {
                collid.gameObject.GetComponent<GameHandler>().TakeDamage(damage);
                canAttack = false;
            }
        }
        //else if (canAttack == true && collid.gameObject.CompareTag("Player"))
        //{
        //    canAttack = false;
        //    StartCoroutine("Attack");
        //}
    }

    public void Follow()
    {
        if (Vector2.Distance(transform.position, target.transform.position) > 0.15f && ennemiCanMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.2f);

        canAttack = true;
        playerCollider.enabled = false;

        yield return new WaitForSeconds(0.5f);

        canAttack = false;
        playerCollider.enabled = true;
    }

}
