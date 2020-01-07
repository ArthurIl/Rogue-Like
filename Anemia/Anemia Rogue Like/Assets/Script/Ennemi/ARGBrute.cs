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
    public GameObject altar;

    public Collider2D playerCollider;
    public CircleCollider2D slamAttaque;

    private Vector2 direction;
    private Animator anim;
    public GameObject brute;

    void Start()
    {
        var bruteColor = brute.GetComponent<Renderer>();
        GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
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
        direction = (target.transform.position - transform.position).normalized;
        anim.SetFloat("BruteMoveX", direction.x);

        Follow();
        DeathBig();

        if (ennemiHealth <= 10 && !secondPhase)
        {
            tag = "Ennemi";
            secondPhase = true;
            //animator drainale (changement de sprite)
        }
        if (secondPhase == true)
        {
            anim.SetLayerWeight(1, 0);
        }
        else anim.SetLayerWeight(1, 1);

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

            //if (secondPhase == true)
            //{
            //    //animator drainable
            //}
            //else
            //{
            //    //animator non drainable
            //}


        }

        if (Vector2.Distance(transform.position, target.transform.position) < slameRange && isActive == false && ennemiCanSlam)
        {
            StartCoroutine("Slam");
            anim.SetBool("isAttaque", true);
        } 


        if (Vector2.Distance(transform.position, target.transform.position) > chargeRange && ennemiCanMove && ennemiCanCharge)
        {
            StartCoroutine("Charge");
            anim.SetBool("isDashing", true);
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
        anim.SetBool("isAttaque", false);
        yield return new WaitForSeconds(2f); //temps immobilisé après le slam
        ennemiCanSlam = true;
        ennemiCanMove = true;

        //if (secondPhase == true)
        //{
        //    //animator drainable
        //}
        //else
        //{
        //    //animator non drainable
        //}
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
                anim.SetBool("isDashing", false);
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

        
    }

    public void DeathBig()
    {
        if (ennemiHealth <= 0)
        {
            Instantiate(souls, new Vector3(transform.position.x , transform.position.y + 0.3f, 0), Quaternion.identity);
            Instantiate(altar,new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            Destroy(this.gameObject);
        }
    }


}
