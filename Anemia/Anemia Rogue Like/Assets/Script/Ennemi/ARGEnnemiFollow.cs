using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARGEnnemiFollow : ARGEnnemi
{
    private bool canAttack;
    public Collider2D playerCollider;
    private GameObject player;
    private bool inRange;
    public Collider2D rangeDammage;
    private Animator anim;
    private Vector2 direction;
    void Start()
    {
        anim = GetComponent<Animator>();
        ennemiCanMove = true;
        target = GameObject.FindGameObjectWithTag("Player");
        canAttack = true;
        playerCollider = target.GetComponent<Collider2D>();
        rangeDammage = gameObject.GetComponentInChildren<CircleCollider2D>();
        direction = (target.transform.position - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("empalléMoveX", direction.x);
        Debug.Log(direction);

        Follow();
        Death();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && canAttack == true)
        {
            player = other.gameObject;
            rangeDammage.enabled = true;
            StartCoroutine("Attack");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRange = true;
        }
        else inRange = false;
    }

    public void Follow()
    {
        if (Vector2.Distance(transform.position, target.transform.position) > 0.15f && ennemiCanMove)
        {
            direction = (target.transform.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }

    IEnumerator Attack()
    {
        speed = 0;
        anim.SetBool("isAttack", true);
        yield return new WaitForSeconds(0.3f);

        playerCollider.enabled = false;
        canAttack = false;


        if (inRange == true)
        {
            player.gameObject.GetComponent<GameHandler>().TakeDamage(damage);
        }

        yield return new WaitForSeconds(0.5f);
        anim.SetBool("isAttack", false);
        rangeDammage.enabled = false;
        canAttack = true;
        playerCollider.enabled = true;
        speed = 0.2f;
    }

}
