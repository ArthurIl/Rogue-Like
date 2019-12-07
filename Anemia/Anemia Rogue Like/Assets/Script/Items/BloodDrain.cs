using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodDrain : MonoBehaviour
{
    public float regenMultiplier;
    private GameHandler script;

    private void Start()
    {
        script = GameObject.FindGameObjectWithTag("Player").GetComponent<GameHandler>();
        script.haveMoreBlood = true;
        script.drainHeal = script.drainHeal * regenMultiplier;

    }
}
