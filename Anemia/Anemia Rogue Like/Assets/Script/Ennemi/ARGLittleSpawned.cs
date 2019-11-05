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

    // Start is called before the first frame update
    void Start()
    {
        littleSpawnedRb = GetComponent<Rigidbody2D>();
        ennemiCanMove = true;
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
    }

  void Follow()
     {
         if (Vector2.Distance(transform.position, target.transform.position) > dashDTriggeristance && ennemiCanMove)
         {
             transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
         }
         else if (Vector2.Distance(transform.position, target.transform.position) < dashDTriggeristance && Vector2.Distance(transform.position, target.transform.position) > playerDashDistance && ennemiCanMove && canDash == true)
         {
             StartCoroutine("Dash");
         }
         else if (Vector2.Distance(transform.position, target.transform.position) < playerDashDistance && ennemiCanMove)
         {
             transform.position = Vector2.MoveTowards(transform.position, target.transform.position, -speed * Time.deltaTime);
         }
     }

    IEnumerator Dash()
    {
        ennemiCanMove = false;
        canDash = false;
        float timer = 0.0f;

        yield return new WaitForSeconds(startDashTime);

        while (timer < dashTime)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime) * dashSpeed * dashCurve.Evaluate(timer / dashTime);
            timer += Time.deltaTime;

            yield return null;
        }
        ennemiCanMove = true;
    }
}
