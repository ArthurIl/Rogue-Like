using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARGLittleSpawned : ARGEnnemi
{
    public float dashDTriggeristance;
    public float playerDashDistance;
    private bool canDash;

    [SerializeField]
    private AnimationCurve dashCurve;
    [SerializeField]
    private float dashTime;

    // Start is called before the first frame update
    void Start()
    {
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
         else if (Vector2.Distance(transform.position, target.transform.position) < dashDTriggeristance && Vector2.Distance(transform.position, target.transform.position) > playerDashDistance && ennemiCanMove && canDash)
         {
             transform.position = this.transform.position;
             StartCoroutine("Dash");
            EnnemiDash();

        }
         else if (Vector2.Distance(transform.position, target.transform.position) < playerDashDistance && ennemiCanMove)
         {
             transform.position = Vector2.MoveTowards(transform.position, target.transform.position, -speed * Time.deltaTime);
         }
     }

    IEnumerator Dash()
    {
        canDash = false;
        Debug.Log("la coroutine a démaré" + canDash);
        yield return new WaitForSeconds(5f);

        canDash = true;
    }

    void EnnemiDash()
    {
        float timer = 0.0f;
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * dashCurve.Evaluate(timer / dashTime) * Time.deltaTime);
    }
}
