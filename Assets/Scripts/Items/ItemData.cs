using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public int price;

    public abstract string typeName { get; }
}

