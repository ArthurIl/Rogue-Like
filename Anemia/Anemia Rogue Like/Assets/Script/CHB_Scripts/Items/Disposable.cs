using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Disposable", menuName = "Item/Disposable")]

public class Disposable : Item
{
    public float healthRefill;
    public float dammageBoost;
    public int soulsAdd;
    public override ItemType WhatType()
    {
        type = ItemType.DISPOSABLE;

        return type;
    }

    public override void BehaviorToPlayer()
    {
        throw new System.NotImplementedException();
    }


    public float HitMore(float pAttackDamage)
    {
        pAttackDamage += dammageBoost;

        return pAttackDamage;
    }

    public int GiveSouls(int pSoulsCount)
    {
        pSoulsCount += soulsAdd;

        return pSoulsCount;
    }
}
