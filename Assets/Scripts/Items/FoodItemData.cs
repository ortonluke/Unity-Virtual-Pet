using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Food Item", menuName = "Item/Food Item")]
public class FoodItemData : ItemData
{
    public int saturation;

    public override string typeName => "Food";
}
