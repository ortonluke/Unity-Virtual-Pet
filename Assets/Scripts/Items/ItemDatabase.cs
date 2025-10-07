using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<ItemData> allItems;

    // Utility function: get items by type
    public List<ItemData> GetItemsByType(string type)
    {
        return allItems.FindAll(item => item.typeName == type);
    }
}
