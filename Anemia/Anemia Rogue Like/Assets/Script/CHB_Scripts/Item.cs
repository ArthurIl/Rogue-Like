using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType { WEAPON, TRINKET, DISPOSABLE}
[CreateAssetMenu(fileName = "New Item", menuName = "ScriptObject/Item")]
public class Item : ScriptableObject
{
    public ItemType type;
    public Sprite itemSprite;
}
