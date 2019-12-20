using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodDrain : MonoBehaviour
{
    //public float multiplier;
    private CharacterMovement script;
    private GameHandler scriptG;
    public Trinket bloodD;
    //public float fasterCharge;

    private void Start()
    {
        script = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>();
        scriptG = GameObject.FindGameObjectWithTag("Player").GetComponent<GameHandler>();
        //mouvement
        script.stockAcceleration = bloodD.acceleration;
        script.stockCooldown = bloodD.dashCooldown;
        //drain
        scriptG.storeDrainHeal = bloodD.drainHeal;
        //attrition
        scriptG.stockAttrition = bloodD.attrition;

    }
}
