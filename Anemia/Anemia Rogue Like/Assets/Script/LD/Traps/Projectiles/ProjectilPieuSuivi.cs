using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilPieuSuivi : MonoBehaviour
{
    public float speed;
    
    public GameObject player;
    public float damage;
    RaycastHit2D hitInfo;
    private Vector2 positionTarget;
    public Transform projectil;

    // Start is called before the first frame update

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Start()
    {
        
        //target = new Vector2(player.position.x, player.position.y);
        int layer_mask = LayerMask.GetMask("Wall");
        hitInfo = Physics2D.Raycast(transform.position, player.transform.position - transform.position, 10f, layer_mask);
        //positionTarget = new Vector2(hitInfo.point.x, hitInfo.point.y);
        positionTarget = hitInfo.point;
        Debug.DrawLine(transform.position, positionTarget, Color.red, 10f);
       // Debug.Log("self pos = " + transform.position);
        /*Debug.Log("target pos = " + player.transform.position);
        Debug.Log("transformed value = " + positionTarget);*/
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, positionTarget, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<GameHandler>().TakeDamage(damage);
            DestroyProjectile();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}