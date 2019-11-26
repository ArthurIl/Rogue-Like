using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    //Statement déplacement
    [SerializeField]
    public float acceleration;
    private float stockAcceleration;
    private Rigidbody2D playerRb;

    //Statement Dash
    [SerializeField]
    private float dashSpeed;
    [SerializeField]
    private float dashTime;
    [SerializeField]
    private float dashCooldown;
    [SerializeField]
    private float maxDashCooldown;
    private int direction;
    [SerializeField]
    protected bool canDash = true;
    protected bool canMove;
    public Collider2D playerCollider;
    public LayerMask enemy;
    public LayerMask wall;
    public LayerMask trap;
    public float enemyDistance;
    [SerializeField]
    private Image dashBar;
    private bool isCooldown;

    

    Vector3 movement;
    public bool isActive = true;
    public bool haveBoot = false;

    [SerializeField]
    private AnimationCurve dashCurve;



    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();
        stockAcceleration = acceleration;
    }

    // Update is called once per frame
    void Update()
    {
        CDFeedback();
        if (isActive == true) {

            movement = new Vector3(Input.GetAxisRaw("MoveHorizontal"), Input.GetAxisRaw("MoveVertical"), 0f).normalized;
            if (Input.GetButtonDown("Dash") && canDash)
            {
                movement = new Vector3(Input.GetAxis("MoveHorizontal"), Input.GetAxis("MoveVertical"), 0f).normalized;
                if (Input.GetButtonDown("Dash") && canMove)
                {
                    Dashing(movement);
                }
                else
                    Move(movement);
            }
            else
            {
                Move(movement);
            }
        }
        if (haveBoot == false)
        {
            acceleration = stockAcceleration;
        }


        RaycastHit2D wallHit = Physics2D.Raycast(transform.position, movement, enemyDistance, wall);
        if (wallHit)
        {
            playerCollider.enabled = true;
        }
    }


    //mouvement du joueur en récupérant les axes du stick de la manette + accélération modifiable dans l'inspector
    public void Move(Vector3 direction)
    {
      playerRb.velocity = direction.normalized * acceleration * Time.deltaTime;
    }

    //IEnumerator dash(Vector3 movement)
    //{

    //    canMove = false;
    //    playerRb.velocity = movement * dashSpeed;

    //    yield return new WaitForSeconds(dashTime);
    //    playerRb.velocity = Vector2.zero;
    //    canMove = true;
    //}
    public void Dashing(Vector3 direction)
    {
        //StartCoroutine("dash", movement);
        StartCoroutine(SmoothDash(direction));
    }

    IEnumerator SmoothDash(Vector3 direction)
    {
        float timer = 0.0f;  
        canDash = false;

        RaycastHit2D enemyHit = Physics2D.Raycast(transform.position, direction, enemyDistance, enemy);
        RaycastHit2D trapHit = Physics2D.Raycast(transform.position, direction, enemyDistance, trap);
        if (enemyHit || trapHit)
        {
            playerCollider.enabled = false;
        }

        while (timer < dashTime)
        {
            playerRb.velocity = direction.normalized * dashSpeed * dashCurve.Evaluate(timer / dashTime);

            timer += Time.deltaTime;
            yield return null;
        }

        playerRb.velocity = Vector2.zero;
        playerCollider.enabled = true;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;

    }

    private void CDFeedback()
    {
        if (Input.GetButtonDown("Dash"))
        {
            isCooldown = true;
        }
        if(isCooldown == true)
        {
            dashBar.fillAmount += 1 / dashCooldown * Time.deltaTime;
            if (dashBar.fillAmount >= 1)
            {
                dashBar.fillAmount = 0;
                isCooldown = false;
            }
        }
    }

    public void Paralysis()
    {
        isActive = false;
    }

    public void Unparalysed()
    {
        isActive = true;
    }

}