using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType { WEAPON, TRINKET, DISPOSABLE}

public abstract class Item : ScriptableObject
{
    protected ItemType type;

    public abstract ItemType WhatType();
    public abstract void BehaviorToPlayer();
}
