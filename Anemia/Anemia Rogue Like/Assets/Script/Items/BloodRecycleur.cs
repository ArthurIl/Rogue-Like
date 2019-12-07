using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodRecycleur : MonoBehaviour
{
    public float slowerFall;
    private GameHandler gameHandlerScript;
    private CharacterMovement characterControllerScript;
    private bool done;
    private void Start()
    {
        gameHandlerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<GameHandler>();
        characterControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>();

        
    }

    private void Update()
    {
        if (characterControllerScript.isMoving == true && done == false)
        {
            gameHandlerScript.haveBloodRecycler = true;
            gameHandlerScript.attrition = gameHandlerScript.attrition * slowerFall;
            done = true;
        }
        else
        {
            gameHandlerScript.haveBloodRecycler = false;
            done = false;
        }
    }
}
