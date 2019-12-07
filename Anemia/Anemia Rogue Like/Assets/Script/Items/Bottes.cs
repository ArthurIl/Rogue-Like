using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottes : MonoBehaviour
{
    public float multiplier;
    private CharacterMovement script;
    public float fasterCharge;

    private void Start()
    {   
        script = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>();
        script.haveBoot = true;
        script.acceleration = script.acceleration * multiplier;
        script.dashCooldown = script.dashCooldown * fasterCharge;

    }
}
