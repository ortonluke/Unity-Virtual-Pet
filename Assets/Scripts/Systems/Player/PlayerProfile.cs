using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerProfile
{
    public string playerName = "Steve";
    public float hunger = 1;
    public float mood = 1;
    public float energy = 1;
    public int money = 1000;

    [System.Serializable]
    public class ItemSave
    {
        public string itemID;
        public int quantity;
    }

    public List<ItemSave> inventory = new List<ItemSave>();
}
