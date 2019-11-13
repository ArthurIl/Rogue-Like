using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timed_Spikes : MonoBehaviour
{
    [SerializeField]
    private float damage = 0.5f;
    
    public Collider2D spikes;

    private void Start()
    {
        spikes = GetComponent<Collider2D>();
        InvokeRepeating("Timer", 1.0f, 5.0f);
    }
   

    private void Timer()
    {
        spikes.enabled = !spikes.enabled;
        Debug.Log("Collider.enabled = " + spikes.enabled);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<GameHandler>().TakeDamage(damage);
            
        }
    }
}
