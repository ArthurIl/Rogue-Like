using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Disposable", menuName = "Item/Disposable")]

public class Disposable : Item
{
    public override ItemType WhatType()
    {
        type = ItemType.DISPOSABLE;

        return type;
    }
}
