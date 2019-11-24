using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARGBrute : ARGEnnemi
{
    public float slameRange;
    public float chargeRange;
    public float chargeSpeed;
    public float followRange;
    private bool ennemiCanCharge;
    private bool isActive;
    private bool isTouchingAWall;
    private Vector2 positionTarget;
    RaycastHit2D hitInfo;

    public Collider2D playerCollider;

    void Start()
    {
        isActive = false;
        ennemiCanMove = true;
        isTouchingAWall = false;
        ennemiCanCharge = true;

        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
        Death();

        if (isActive == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, positionTarget, 2 * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<GameHandler>().TakeDamage(damage);
            StartCoroutine(PlayerImmuned());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            StartCoroutine("Stun");

        }
    }

    public void Follow()
    {
        if (Vector2.Distance(transform.position, target.transform.position) < followRange && ennemiCanMove && isActive == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        }

        if (Vector2.Distance(transform.position, target.transform.position) < slameRange && isActive == false)
        {
            StartCoroutine("Slam");
        }

        if (Vector2.Distance(transform.position, target.transform.position) > chargeRange && ennemiCanMove && ennemiCanCharge)
        {
            StartCoroutine("Charge");
        }
    }

    IEnumerator Slam()
    {
        yield return null;
    }

    IEnumerator Charge()
    {
        ennemiCanCharge = false;
        int layer_mask = LayerMask.GetMask("Wall");
        //Debug.DrawLine(transform.position, target.transform.position, Color.red, 10f);
        hitInfo = Physics2D.Raycast(transform.position, target.transform.position - transform.position, Mathf.Infinity, layer_mask);
        //Debug.DrawLine(transform.position, hitInfo.point, Color.blue, 10f);
        positionTarget = new Vector2(hitInfo.point.x * 0.92f, hitInfo.point.y * 0.92f);
        /*Debug.Log("Position du joueur est " + target.transform.position);
        Debug.Log("position ennemi " + transform.position);
        Debug.Log("position du point target est " + positionTarget);*/
        isActive = true;
        if (isActive == true)
            
        {

            if (isTouchingAWall)
            {
                yield return new WaitForSeconds(1f);
                ennemiCanCharge = true;
                isActive = false;
            }
            else
            {
                yield return new WaitForSeconds(2f);
                ennemiCanCharge = true;
                isActive = false;
            }            

        }

    }

    IEnumerator Stun()
    {
        isTouchingAWall = true;
        yield return new WaitForSeconds(1f);
        isTouchingAWall = false;
        yield return null;
    }

    private IEnumerator PlayerImmuned()
    {
        playerCollider.enabled = false;

        yield return new WaitForSeconds(0.5f);

        playerCollider.enabled = true;

    }

}
