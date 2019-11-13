using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType { WEAPON, TRINKET, DISPOSABLE}

public abstract class Item : ScriptableObject
{
    protected ItemType type;
    public Sprite itemSprite;

    public abstract ItemType WhatType();
}
