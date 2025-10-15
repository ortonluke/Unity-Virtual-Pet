using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Food Item", menuName = "Item/Food Item")]
public class FoodItemData : ItemData
{
    public int saturation;

    public override string typeName => "Food";

    public override float stat1 => saturation;
    public override float stat2 => 0;
    public override float stat3 => 0;
}
