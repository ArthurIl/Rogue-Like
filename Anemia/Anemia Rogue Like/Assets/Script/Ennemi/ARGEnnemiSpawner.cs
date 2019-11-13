using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARGEnnemiSpawner : ARGEnnemi
{
    public GameObject little;
    public GameObject target;
    private float waitTime = 5f;
    public bool canInvoke = true;

    // Start is called before the first frame update
    void Start()
    {
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
        canInvoke = false;
        Instantiate(little, transform.position, Quaternion.identity);

        yield return new WaitForSeconds(5f);

        canInvoke = true;
    }
}
