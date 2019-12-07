using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonFangs : MonoBehaviour
{
    public float damage;
    private GameHandler script;
    protected float timeBtwDamages;
    public float startTimeBtwDamages;

    private void Start()
    {
        script = GameObject.FindGameObjectWithTag("Player").GetComponent<GameHandler>();

    }
    
    protected IEnumerator Poison()
    {
        if (timeBtwDamages < +0 && script.useDrain == true)
        {
            
            timeBtwDamages = startTimeBtwDamages;
        }
        else
        {
            timeBtwDamages -= Time.deltaTime;
        }
        yield return null;
    }

    private void Update()
    {
        Poison();
    }
}
