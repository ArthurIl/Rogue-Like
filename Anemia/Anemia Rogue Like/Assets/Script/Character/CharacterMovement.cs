﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //Statement déplacement
    [SerializeField]
    private float acceleration;

    private Rigidbody2D playerRb;

    //Statement Dash
    [SerializeField]
    private float dashSpeed;
    [SerializeField]
    private float dashTime;
    [SerializeField]
    private float dashCooldown;
    private int direction;
    [SerializeField]
    protected bool canDash = true;
    protected bool canMoove;
    public Collider2D playerCollider;
    public LayerMask enemy;
    public LayerMask wall;
    public float enemyDistance;

    Vector3 movement;

    [SerializeField]
    private AnimationCurve dashCurve;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(Input.GetAxisRaw("MoveHorizontal"), Input.GetAxisRaw("MoveVertical"), 0f).normalized;
        if (Input.GetButtonDown("Dash") && canDash)
        {
            Dashing(movement);
        }
        else
        {
            Move(movement);
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
        if(enemyHit)
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
}