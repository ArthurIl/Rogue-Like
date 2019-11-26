using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanAttack : MonoBehaviour
{
    public static bool canAttackInRange;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            canAttackInRange = true;
        }
        else
        {
            canAttackInRange = false;
        }
    }
}
