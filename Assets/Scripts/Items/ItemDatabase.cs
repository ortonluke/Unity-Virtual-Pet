using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<ItemData> allItems;

    public List<ItemData> shopItems;
    public int numberOfShopItems;

    // Utility function: get items by type
    public List<ItemData> GetItemsByType(string type)
    {
        return allItems.FindAll(item => item.typeName == type);
    }

    public List<ItemData> GetShopItems()
    {
        List<ItemData> items = new List<ItemData>();
        int count = Mathf.Min(numberOfShopItems, allItems.Count);

        for (int i = 0; i < count; i++)
        {
            items.Add(allItems[i]);
        }

        return items;
    }


}
