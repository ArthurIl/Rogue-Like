using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerModifier : MonoBehaviour
{
    public Weapon dagger;

    public GameHandler attack;

    private void Start()
    {
        attack = GameObject.FindGameObjectWithTag("Player").GetComponent<GameHandler>();
        attack.attackDammage = dagger.attackDammage;
        attack.attackRangeX = dagger.attackRangeX;
        attack.attackRangeY = dagger.attackRangeY;
        attack.timeBtwAttack = dagger.timeBtwAttack;
    }


}
