using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARGEnnemiDistance : ARGEnnemi
{
    public float shootDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShot;

    private Vector2 direction;

    public GameObject projectile;
    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        canShoot = true;
        ennemiCanMove = true;
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (ennemiCanMove == false)
        {
            StartCoroutine(ShlagStagger());
        }

        direction = (target.transform.position - transform.position).normalized;
        anim.SetFloat("ennemiDMoveX", direction.x);
        //Debug.Log(direction.x);
        Follow();
        Shoot();
        Death();
    }

    void Follow()
    {
        if (Vector2.Distance(transform.position, target.transform.position) > shootDistance && ennemiCanMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            canShoot = false;
            


        }
        else if (Vector2.Distance(transform.position, target.transform.position) < shootDistance && Vector2.Distance(transform.position, target.transform.position) > retreatDistance && ennemiCanMove)
        {
            transform.position = this.transform.position;
            canShoot = true;


        }
        else if (Vector2.Distance(transform.position, target.transform.position) < retreatDistance && ennemiCanMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, -speed * Time.deltaTime);
            canShoot = false;
        }
    }
    void Shoot()
    {
        if (timeBtwShots <+0 && canShoot == true)
        {
            anim.SetBool("isAttack", true);
            StartCoroutine(FixAnimation());
            timeBtwShots = startTimeBtwShot;
        } else
        {
            anim.SetBool("isAttack", false);
            timeBtwShots -= Time.deltaTime;
        }
    }
    private IEnumerator FixAnimation()
    {
        yield return new WaitForSeconds(0.4f);
        Instantiate(projectile, transform.position, Quaternion.identity);
        //Debug.Log(transform.position);
    }
    private IEnumerator ShlagStagger()
    {
        anim.SetBool("isStagger", true);
        yield return new WaitForSeconds(1f);
        anim.SetBool("isStagger", false);
    }
}
