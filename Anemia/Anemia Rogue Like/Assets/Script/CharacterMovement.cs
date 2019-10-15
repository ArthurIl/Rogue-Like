using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private float acceleration;
    [SerializeField]
    private float dashSpeed;
    private Rigidbody2D playerRb;
    [SerializeField]
    private float dashTime;
    private int direction;
    private bool canMove;
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
        if (Input.GetButtonDown("Dash"))
        {
            isDashing(movement);
        }
        else
             Move(movement);
    }

    //mouvement du joueur en récupérant les axes du stick de la manette + accélération modifiable dans l'inspector
    public void Move(Vector3 movement)
    {
       transform.position = transform.position + movement * acceleration * Time.deltaTime;
    }

    //IEnumerator dash(Vector3 movement)
    //{

    //    canMove = false;
    //    playerRb.velocity = movement * dashSpeed;

    //    yield return new WaitForSeconds(dashTime);
    //    playerRb.velocity = Vector2.zero;
    //    canMove = true;
    //}
    public void isDashing(Vector3 movement)
    {
        //StartCoroutine("dash", movement);
        StartCoroutine(SmoothDash(movement));
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
        canMove = true;
    }
}