using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Item/Weapon")]
public class Weapon : Item
{
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
