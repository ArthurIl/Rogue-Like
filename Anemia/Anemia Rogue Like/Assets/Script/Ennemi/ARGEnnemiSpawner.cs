using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARGEnnemiSpawner : ARGEnnemi
{
    public GameObject little;
    private float waitTime = 5f;
    public bool canInvoke = true;
    public float timeBetweenInvoke;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null && canInvoke == true)
        {
            StartCoroutine("Invoke");
        }
        Death();
    }

    IEnumerator Invoke()
    {
        anim.SetBool("isSpawned", true);
        canInvoke = false;
        StartCoroutine(Instantiate());

        yield return new WaitForSeconds(1.2f);
        anim.SetBool("isSpawned", false);
        yield return new WaitForSeconds(timeBetweenInvoke);

        canInvoke = true;
    }

    IEnumerator Instantiate()
    {
        yield return new WaitForSeconds(0.45f);
        Instantiate(little, transform.position, Quaternion.identity);
    }
}
