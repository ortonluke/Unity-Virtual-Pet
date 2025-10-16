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
        //THIS SHOULD ONLY RUN AT THE START OF THE GAME, NOT BETWEEN SCENES, DON'T KNOW IF THIS WILL BREAK!
        ClearQuantities();

        MakeShopItems();
    }

    // Utility function: get items by type
    public List<ItemData> GetItemsByType(string type)
    {
        return allItems.FindAll(item => item.typeName == type);
    }

    public void MakeShopItems()
    {
        //creates the first n number of shopItems. 
        int count = Mathf.Min(numberOfShopItems, allItems.Count);

        for (int i = 0; i < count; i++)
        {
            shopItems.Add(allItems[i]);
        }
    }

    public void AddToInventory(ItemData item)
    {
        foreach (ItemData i in inventoryItems)
        {
            if (i.name == item.name)
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
