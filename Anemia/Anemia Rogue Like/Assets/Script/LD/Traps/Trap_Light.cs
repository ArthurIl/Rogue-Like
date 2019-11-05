using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Light : MonoBehaviour
{
    [SerializeField]
    public float modifier = 2;
    public float originalAttrition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject Player = GameObject.Find("Player");
        GameHandler attritionModifier = Player.GetComponent<GameHandler>();       
        originalAttrition = attritionModifier.attrition;
        if (collision.gameObject.tag == "Player")
        {
            attritionModifier.attrition *= modifier;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject Player = GameObject.Find("Player");
        GameHandler attritionModifier = Player.GetComponent<GameHandler>();
        if (collision.gameObject.tag == "Player")
        {
            attritionModifier.attrition = originalAttrition;
        }
    }


}
