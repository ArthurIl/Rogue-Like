using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancePieuAnim : MonoBehaviour
{
    private Animator anim;
    public Lance_pieu_aim LancePieu;
    public GameObject LancePieuAim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        LancePieu = LancePieuAim.GetComponent<Lance_pieu_aim>();
    }
    // Update is called once per frame
    void Update()
    {
        if (LancePieu.timeBtwShots > 1)
        {
            anim.SetBool("isNoPique", true);
        }
        else
        {
            anim.SetBool("isNoPique", false);
        }
    }
}
