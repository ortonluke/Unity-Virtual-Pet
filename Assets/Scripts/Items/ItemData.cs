using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public int price;
    public string description;
    public int quantity;

    public int buyMaxNum;

    public abstract string typeName { get; }

    public abstract float stat1 { get; }
    public abstract float stat2 { get; }
    public abstract float stat3 { get; }
}

