using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Shop/Item")]

public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public int price;
    public ItemType type;
}
public enum ItemType
{
    Weapon,
    Armor,
    Consumable,
    
}

