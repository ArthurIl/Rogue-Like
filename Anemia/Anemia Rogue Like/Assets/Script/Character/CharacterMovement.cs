using System.Collections;
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
            WalkAnimation();
        }


    }


    //mouvement du joueur en récupérant les axes du stick de la manette + accélération modifiable dans l'inspector
    public void Move(Vector3 direction)
    {
      playerRb.velocity = direction.normalized * acceleration * Time.deltaTime;
    }

    public void WalkAnimation()
    {
        if (playerRb.velocity != Vector2.zero)
        {
            anim.SetFloat("MoveX", Input.GetAxisRaw("MoveHorizontal"));
            anim.SetFloat("MoveY", Input.GetAxisRaw("MoveVertical"));
            anim.SetBool("Moving", true);
        }
        else
        {
            anim.SetBool("Moving", false);
        }
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

        while (timer < dashTime)
        {
            playerRb.velocity = direction.normalized * dashSpeed * dashCurve.Evaluate(timer / dashTime);

            timer += Time.deltaTime;
            yield return null;
        }

        playerRb.velocity = Vector2.zero;
        

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;

    }
}