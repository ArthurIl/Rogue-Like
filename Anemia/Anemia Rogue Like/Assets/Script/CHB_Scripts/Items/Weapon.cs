using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Item/Weapon")]
public class Weapon : Item
{
    public float attackDammage;
    public float attackRangeX;
    public float attackRangeY;
    public float timeBtwAttack;
    public override ItemType WhatType()
    {
        type = ItemType.WEAPON;

        return type;
    }

    public override void BehaviorToPlayer()
    {
        throw new System.NotImplementedException();
    }
}
