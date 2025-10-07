using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBuilder : MonoBehaviour
{
    private ItemDatabase database;

    public GameObject itemButtonPrefab; //Template for UI button
    public Transform itemListParent; // Panel to set as parent

    [SerializeField] private List<ItemData> shopItems = new List<ItemData>(); //list of only items shown in shop

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
        shopItems = database.GetShopItems();

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
}
