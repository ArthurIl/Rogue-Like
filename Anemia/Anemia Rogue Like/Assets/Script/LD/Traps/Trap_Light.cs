using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Light : MonoBehaviour
{
    [SerializeField]
    public float modifier;
    public float originalAttrition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameHandler attritionModifier = collision.GetComponent<GameHandler>();
            originalAttrition = attritionModifier.attrition;
            attritionModifier.stockAttrition *= modifier;
            
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameHandler attritionModifier = collision.GetComponent<GameHandler>();
            attritionModifier.stockAttrition = originalAttrition;
        }


    }
}
