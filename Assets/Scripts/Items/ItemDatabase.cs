using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<ItemData> allItems;

    // Utility function: get items by type
    public List<ItemData> GetItemsByType(ItemType type)
    {
        return allItems.FindAll(item => item.type == type);
    }
}
