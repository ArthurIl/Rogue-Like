using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottes : MonoBehaviour
{
    private float speed;
    public float multiplier;
    public CharacterMovement script;

    private void Start()
    {
        script = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>();
        script.haveBoot = true;
        script.acceleration = script.acceleration * multiplier;
    }
}
