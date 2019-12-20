using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Trinket", menuName = "Item/Trinket")]
public class Trinket : Item
{
    public float drainHeal;

    public float acceleration;
    public float dashCooldown;

    public float attrition;


    public override ItemType WhatType()
    {
        type = ItemType.TRINKET;

        return type;
    }

    public override void BehaviorToPlayer()
    {
        throw new System.NotImplementedException();
    }
}
