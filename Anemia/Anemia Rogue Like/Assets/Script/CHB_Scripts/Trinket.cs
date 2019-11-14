using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Trinket", menuName = "Item/Trinket")]
public class Trinket : Item
{
    public override ItemType WhatType()
    {
        type = ItemType.TRINKET;

        return type;
    }
}
