using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARGDummy : ARGEnnemi
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        ennemiCanMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (ennemiCanMove == false)
        {
            StartCoroutine(ShlagStagger());
        }
    }
    private IEnumerator ShlagStagger()
    {
        anim.SetBool("isStagger", true);
        yield return new WaitForSeconds(1f);
        anim.SetBool("isStagger", false);
    }
}
