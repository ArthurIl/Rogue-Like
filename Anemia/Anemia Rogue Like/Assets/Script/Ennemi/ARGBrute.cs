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
    private bool secondPhase;
    private bool ennemiCanSlam;
    private Vector2 positionTarget;
    RaycastHit2D hitInfo;

    public Collider2D playerCollider;
    public CircleCollider2D slamAttaque;
    void Start()
    {
        isActive = false;
        ennemiCanMove = true;
        isTouchingAWall = false;
        ennemiCanCharge = true;
        ennemiCanSlam = true;

        target = GameObject.FindGameObjectWithTag("Player");
        playerCollider = target.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
        Death();
        Drainable();

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

            if (secondPhase == true)
            {
                //animator drainable
            }
            else
            {
                //animator non drainable
            }


        }

        if (Vector2.Distance(transform.position, target.transform.position) < slameRange && isActive == false && ennemiCanSlam)
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
        ennemiCanSlam = false;
        ennemiCanMove = false;
        yield return new WaitForSeconds(1f); //délai avant attaque
        slamAttaque.enabled = true;
        yield return new WaitForSeconds(0.5f); // temps que reste la zone
        slamAttaque.enabled = false;
        yield return new WaitForSeconds(2f); //temps immobilisé après le slam
        ennemiCanSlam = true;
        ennemiCanMove = true;

        if (secondPhase == true)
        {
            //animator drainable
        }
        else
        {
            //animator non drainable
        }
    }

    IEnumerator Charge()
    {
        ennemiCanCharge = false;
        int layer_mask = LayerMask.GetMask("Wall");
        hitInfo = Physics2D.Raycast(transform.position, target.transform.position - transform.position, Mathf.Infinity, layer_mask);
        positionTarget = new Vector2(hitInfo.point.x * 0.92f, hitInfo.point.y * 0.92f);
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

    void Drainable()
    {
        if (ennemiHealth <= 10)
        {
            secondPhase = true;
            transform.gameObject.tag = "Ennemi";
            //animator drainale (changement de sprite)
        }
        
    }

}
