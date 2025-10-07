using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    private ItemDatabase database;

    public GameObject itemButtonPrefab; //Template for UI button
    public Transform itemListParent; // Panel to set as parent

    [SerializeField] private List<ItemData> shopItems = new List<ItemData>(); //list of only items shown in shop

    [SerializeField] private int numItemsShow; //count of shop items

    // Hardcoded coordinates for 3x3 grid
    float[] xPositions = { -120f, 0f, 120f };
    float[] yPositions = { 175f, 25f, -125f };

    private void Start()
    {
        database = FindObjectOfType<ItemDatabase>();
        PopulateShop();
    }

    private List<ItemData> GetFoodStock()
    {
        return database.GetItemsByType("Food");
    }

    void PopulateShop()
    {
        shopItems.Clear();

        //GET ITEMS FOR THE SHOP
        shopItems = GetNumItems(numItemsShow);

        //Create UI elements
        int index = 0;

        for (int row = 0; row < yPositions.Length; row++)
        {
            for (int col = 0; col < xPositions.Length; col++)
            {
                if (index >= shopItems.Count) return;

                ItemData item = shopItems[index];
                GameObject button = Instantiate(itemButtonPrefab, itemListParent);

                // Position relative to parent
                RectTransform rt = button.GetComponent<RectTransform>();
                rt.anchoredPosition = new Vector2(xPositions[col], yPositions[row]);

                button.GetComponent<ShopItemUI>().Setup(item);

                index++;
            }
        }
    }

    public List<ItemData> GetNumItems(int countWanted)
    {
        List<ItemData> items = new List<ItemData>();
        int count = Mathf.Min(countWanted, database.allItems.Count);

        for (int i = 0; i < count; i++)
        {
            items.Add(database.allItems[i]);
            Debug.Log("Added to items: " + database.allItems[i].itemName);
        }

        return items;
    }
}
