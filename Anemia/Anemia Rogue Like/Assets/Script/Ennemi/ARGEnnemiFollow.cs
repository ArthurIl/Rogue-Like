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

    }

    // Update is called once per frame
    void Update()
    {
        direction = (target.transform.position - transform.position);
        anim.SetFloat("ennemiCMoveX", direction.x);
        //Debug.Log(direction);

        if (ennemiCanMove == false)
        {
            StartCoroutine(ShlagStagger());
        }


        Follow();
        Death();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && canAttack == true)
        {
            inRange = true;
            player = other.gameObject;
            //rangeDammage.enabled = true;
            StartCoroutine("Attack");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            inRange = false;
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

        canAttack = false;


        if (inRange == true)
        {
            GameHandler.instance.TakeDamage(damage);
            //player.gameObject.GetComponent<GameHandler>().TakeDamage(damage);
        }

        yield return new WaitForSeconds(1f);
        anim.SetBool("isAttack", false);
        //rangeDammage.enabled = false;
        canAttack = true;
        speed = 0.2f;
    }

    private IEnumerator ShlagStagger()
    {
        anim.SetBool("isStagger", true);
        yield return new WaitForSeconds(1f);
        anim.SetBool("isStagger", false);
    }
}
