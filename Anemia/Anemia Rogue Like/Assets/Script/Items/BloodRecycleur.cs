using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodRecycleur : MonoBehaviour
{

    //public float multiplier;
    private CharacterMovement script;
    private GameHandler scriptG;
    public Trinket bloodRecy;
    //public float fasterCharge;

    private void Start()
    {
        script = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>();
        scriptG = GameObject.FindGameObjectWithTag("Player").GetComponent<GameHandler>();
        //mouvement
        script.stockAcceleration = bloodRecy.acceleration;
        script.stockCooldown = bloodRecy.dashCooldown;
        //drain
        scriptG.storeDrainHeal = bloodRecy.drainHeal;
        //attrition
        scriptG.stockAttrition = bloodRecy.attrition;

    }


    //private void Update()
    //{
    //    if (characterControllerScript.isMoving == true && done == false)
    //    {
    //        gameHandlerScript.haveBloodRecycler = true;
    //        gameHandlerScript.stockAttrition = gameHandlerScript.stockAttrition * slowerFall;
    //        done = true;
    //    }
    //    else
    //    {
    //        gameHandlerScript.haveBloodRecycler = false;
    //        done = false;
    //    }
    //}
}
