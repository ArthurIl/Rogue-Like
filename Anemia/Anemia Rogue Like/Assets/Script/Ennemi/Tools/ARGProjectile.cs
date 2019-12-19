using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARGProjectile : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector2 target;
    public float damage;
    public Collider2D playerCollider;
    private GameObject theTarget;

    // Start is called before the first frame update
    void Start()
    {
        theTarget = GameObject.FindGameObjectWithTag("Player");
        playerCollider = theTarget.GetComponent<Collider2D>();



        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position.x == target.x && transform.position.y == target.y) //ARG Check RayCast
        {
            DestroyProjectile();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {

            other.gameObject.GetComponent<GameHandler>().TakeDamage(damage);
            StartCoroutine(PlayerImmuned());
            DestroyProjectile();
        }
        //else if(other.gameObject.layer == 8){
        //DestroyProjectile();}
    }
    
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    private IEnumerator PlayerImmuned()
    {
        playerCollider.enabled = false;

        yield return new WaitForSeconds(0.1f);

        playerCollider.enabled = true;

    }
}
