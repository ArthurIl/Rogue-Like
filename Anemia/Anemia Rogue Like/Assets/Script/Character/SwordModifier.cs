using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordModifier : MonoBehaviour
{
    public Weapon sword;

    public GameHandler attack;

    private void Start()
    {
        attack = GameObject.FindGameObjectWithTag("Player").GetComponent<GameHandler>();
        attack.attackDammage = sword.attackDammage;
        attack.attackRangeX = sword.attackRangeX;
        attack.attackRangeY = sword.attackRangeY;
        attack.timeBtwAttack = sword.timeBtwAttack;
    }
}
