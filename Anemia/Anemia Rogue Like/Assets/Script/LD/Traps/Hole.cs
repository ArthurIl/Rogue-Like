using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnPoint;
    public float damage;
    private IEnumerator coroutine;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        coroutine = WaitAndRelease(2.0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "Player")
        {
            
            StartCoroutine(coroutine);
            
            collision.gameObject.GetComponent<CharacterMovement>().Paralysis();


        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<CharacterMovement>().Unparalysed();
        collision.gameObject.GetComponent<GameHandler>().TakeDamage(damage);
    }

    private IEnumerator WaitAndRelease(float waitTime)
    {
        Debug.Log("Fallen");
        yield return new WaitForSeconds(2.0f);
        player.transform.position = spawnPoint.transform.position;
    }
        
}
