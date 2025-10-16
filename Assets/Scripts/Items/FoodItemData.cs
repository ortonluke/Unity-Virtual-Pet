using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Food Item", menuName = "Item/Food Item")]
public class FoodItemData : ItemData
{
    public int saturation;
    public int mood;
    public int energy;

    public override string typeName => "Food";

    public override float stat1 => saturation; //Hunger
    public override float stat2 => mood;
    public override float stat3 => energy;
}
