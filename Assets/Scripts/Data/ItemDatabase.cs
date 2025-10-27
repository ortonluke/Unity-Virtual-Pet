using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<ItemData> allItems;

    public List<ItemData> shopItems;
    public int numberOfShopItems;

    public List<ItemData> inventoryItems;

    public int inventoryCapacity = 24;

    void Start()
    {
        //ClearQuantities();

        SetShopItems();
    }

    // Utility function: get items by type
    public List<ItemData> GetItemsByType(string type)
    {
        return allItems.FindAll(item => item.typeName == type);
    }

    public ItemData GetItemByName(string name)
    {
        return allItems.Find(item => item.itemName == name);
    }

    public void SetShopItems()
    {
        //Get foodItems
        List<ItemData> foodItems = GetItemsByType("Food");

        //shuffle the items
        foodItems = foodItems.OrderBy(x => Random.value).ToList();

        //creates the list of n number of shopItems. 
        int count = Mathf.Min(numberOfShopItems, foodItems.Count);
        shopItems = foodItems.GetRange(0, count);
    }

    public void AddToInventory(ItemData item)
    {
        foreach (ItemData i in inventoryItems)
        {
            if (i.itemName == item.itemName)
            {
                return;
            }
        }

        inventoryItems.Add(item);
    }

    public void RemoveFromInventory(ItemData item)
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].name == item.name)
            {
                inventoryItems.RemoveAt(i);
                return;
            }
        }
    }

    public void ClearQuantities()
    {
        foreach (ItemData item in allItems)
        {
            item.quantity = 0;
        }
    }
}
