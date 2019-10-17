using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private float acceleration;

    private Rigidbody2D playerRb;

    [SerializeField]
    private float dashSpeed;
    [SerializeField]
    private float dashTime;
    [SerializeField]
    private float dashCooldown;
    private int direction;
    [SerializeField]
    private bool canMove = true;

    Vector3 movement;

    [SerializeField]
    private AnimationCurve dashCurve;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(Input.GetAxis("MoveHorizontal"), Input.GetAxis("MoveVertical"), 0f).normalized;
        if (Input.GetButtonDown("Dash") && canMove)
        {
            Dashing(movement);
        }
        else
             Move(movement);
    }

    //mouvement du joueur en récupérant les axes du stick de la manette + accélération modifiable dans l'inspector
    public void Move(Vector3 direction)
    {
       transform.position = transform.position + direction * acceleration * Time.deltaTime;
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
        canMove = false;

        while (timer < dashTime)
        {
            playerRb.velocity = direction.normalized * dashSpeed * dashCurve.Evaluate(timer / dashTime);

            timer += Time.deltaTime;
            yield return null;
        }

        playerRb.velocity = Vector2.zero;
        

        yield return new WaitForSeconds(dashCooldown);
        canMove = true;

    }
}