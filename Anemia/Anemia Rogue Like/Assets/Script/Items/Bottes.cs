using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottes : MonoBehaviour
{
    //public float multiplier;
    private CharacterMovement script;
    private GameHandler scriptG;
    public Trinket botte;
    //public float fasterCharge;

    private void Start()
    {   
        script = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>();
        scriptG = GameObject.FindGameObjectWithTag("Player").GetComponent<GameHandler>();
        //mouvement
        script.stockAcceleration = botte.acceleration;
        script.stockCooldown = botte.dashCooldown;
        //drain
        scriptG.storeDrainHeal = botte.drainHeal;
        //attrition
        scriptG.stockAttrition = botte.attrition;

    }
}
