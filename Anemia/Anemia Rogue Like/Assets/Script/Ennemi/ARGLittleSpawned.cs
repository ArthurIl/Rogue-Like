using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARGLittleSpawned : ARGEnnemi
{
    private Rigidbody2D littleSpawnedRb;
    public float dashDTriggeristance;
    public float playerDashDistance;
    public bool canDash = true;
    [SerializeField]
    private float dashSpeed;

    [SerializeField]
    private AnimationCurve dashCurve;
    [SerializeField]
    private float startDashTime;
    [SerializeField]
    private float dashTime;
    private Vector2 positionTarget;
    private Vector2 direction;
    private Animator anim;

    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        littleSpawnedRb = GetComponent<Rigidbody2D>();
        ennemiCanMove = true;
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        direction = (target.transform.position - transform.position);
        anim.SetFloat("LittleSpawnedMoveX", direction.x);
        Follow();
        Death();
    }

  void Follow()
     {
         if (Vector2.Distance(transform.position, target.transform.position) > dashDTriggeristance && ennemiCanMove)
         {
            anim.SetBool("isWalking", true);
             transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
         }
         else if (Vector2.Distance(transform.position, target.transform.position) < dashDTriggeristance && Vector2.Distance(transform.position, target.transform.position) > playerDashDistance && ennemiCanMove && canDash == true)
         {
            anim.SetBool("isWalking", false);
            StartCoroutine("Dash");
         }
         else if (Vector2.Distance(transform.position, target.transform.position) < playerDashDistance && ennemiCanMove)
         {
            anim.SetBool("isWalking", true);
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, -speed * Time.deltaTime);
         }
     }

    IEnumerator Dash()
    {
        ennemiCanMove = false;
        canDash = false;
        float timer = 0.0f;

        yield return new WaitForSeconds(startDashTime);
        positionTarget = new Vector2(target.transform.position.x, target.transform.position.y);

        while (timer < dashTime)
        {
            transform.position = Vector2.MoveTowards(transform.position, positionTarget, dashSpeed * Time.deltaTime * dashCurve.Evaluate(timer / dashTime));
            timer += Time.deltaTime;
            
            yield return null;

            if (transform.position.x == positionTarget.x && transform.position.y == positionTarget.y)
            {
                Instantiate(explosion, new Vector3(positionTarget.x,transform.position.y,0), Quaternion.identity);
                Destroy(this.gameObject);
            }
        }


       
    }

}
