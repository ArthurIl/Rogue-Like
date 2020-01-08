﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    //Statement déplacement
    public float acceleration;
    public float stockAcceleration;
    public Rigidbody2D playerRb;

    //Statement Dash
    public float dashSpeed;
    [SerializeField]
    private float dashTime;
    [SerializeField]
    public float dashCooldown;
    public float stockCooldown;
    [SerializeField]
    private float maxDashCooldown;
    private int direction;
    [SerializeField]
    protected bool canDash = true;
    protected bool canMove;
    public Collider2D playerCollider;
    public Collider2D isTriggerCollider;
    public LayerMask enemy;
    public LayerMask wall;
    public LayerMask trap;
    public float enemyDistance;
    [SerializeField]
    private Image dashBar;
    private bool isCooldown;
    public GameObject dashSmoke;

    

    Vector3 movement;
    public bool isActive;
    public bool haveBoot;
    public bool isMoving;
    [SerializeField]
    private AnimationCurve dashCurve;



    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();
        stockAcceleration = acceleration;
        stockCooldown = dashCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        movement = Vector3.zero;
        movement.x = Input.GetAxis("MoveHorizontal");
        movement.y = Input.GetAxis("MoveVertical");
        if(movement != Vector3.zero)
        {
            anim.SetFloat("moveX", movement.x);
            anim.SetFloat("moveY", movement.y);
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }

        if(this.transform.position.z != -9f)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -9f);
        }

        CDFeedback();
        if (isActive == true)

        {

                movement = new Vector3(movement.x, movement.y, 0f).normalized;
                if (Input.GetButtonDown("Dash") && canDash)
                {
                    anim.SetBool("isDash", true);
                     Dashing(movement);
                    Instantiate(dashSmoke, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);

                }
                else Move(movement);



        }
        if (haveBoot == false)
        {
            acceleration = stockAcceleration;
            dashCooldown = stockCooldown;
        }


        RaycastHit2D wallHit = Physics2D.Raycast(transform.position, movement, enemyDistance, wall);
        if (wallHit)
        {
            playerCollider.enabled = true;
            isTriggerCollider.enabled = true;
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
            isTriggerCollider.enabled = false;
        }

        while (timer < dashTime)
        {
            playerRb.velocity = direction.normalized * dashSpeed * dashCurve.Evaluate(timer / dashTime);

            timer += Time.deltaTime;
            yield return null;
        }
        playerRb.velocity = Vector2.zero;
        playerCollider.enabled = true;
        isTriggerCollider.enabled = true;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
        anim.SetBool("isDash", false);

    }

    private void CDFeedback()
    {
        if (Input.GetButtonDown("Dash") && canDash)
        {

            isCooldown = true;
            dashBar.fillAmount = 0f;
        }
        if(isCooldown == true)
        {
            dashBar.fillAmount += 1f / dashCooldown * Time.deltaTime;
            if (dashBar.fillAmount >= 1f)
            {
                dashBar.fillAmount = 1f;
                isCooldown = false;
            }
        }
    }

    public void Paralysis()
    {
        //Debug.Log("je suis paralyser");
        isActive = false;
        playerRb.velocity = Vector2.zero;
        anim.SetBool("isFalling", true);
    }

    public void Unparalysed()
    {
        isActive = true;
        anim.SetBool("isFalling", false);
    }

}