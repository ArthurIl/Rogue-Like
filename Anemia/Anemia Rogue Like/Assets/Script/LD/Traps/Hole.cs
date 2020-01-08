using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnPoint;
    public float damage;
    private IEnumerator coroutine;
    private bool isInTrigger;
    private bool wasInTrigger;
    private GameObject playerVariable;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        isInTrigger = false;
        playerVariable = null;

    }

    private void FixedUpdate()
    {
        if (wasInTrigger && !isInTrigger )
        {
            wasInTrigger = false;
        }
        isInTrigger = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<CharacterMovement>().Paralysis();
            playerVariable = collision.gameObject;
            StartCoroutine("WaitAndRelease");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
      wasInTrigger = true;
      isInTrigger = true;
    }

    private IEnumerator WaitAndRelease()
    {
        //Debug.Log("Fallen");
        yield return new WaitForSeconds(0.8f);
        player.transform.position = spawnPoint.transform.position;
        playerVariable.gameObject.GetComponent<GameHandler>().TakeDamage(damage);
        playerVariable.gameObject.GetComponent<CharacterMovement>().Unparalysed();
    }
        
}
