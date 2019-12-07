using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulEater : MonoBehaviour
{
    public float soulMultiplier;
    private GameHandler script;

    private void Start()
    {
        script = GameObject.FindGameObjectWithTag("Player").GetComponent<GameHandler>();

    }
}
