using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBuilder : MonoBehaviour
{
    private ItemDatabase database;

    [SerializeField] private GameObject inventoryPrefab;
    [SerializeField] private Transform panel;

    [SerializeField] private List<ItemData> inventoryItems = new List<ItemData>();

    float[] xPositions = { 58.75f, 152.92f, 247.08f, 341.25f };
    float[] yPositions = { -120f, -204f, -288f, -372f, -456f, -540f };

    // Start is called before the first frame update
    void Start()
    {
        database = FindObjectOfType<ItemDatabase>();
        PopulateInventory();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PopulateInventory()
    {
        inventoryItems.Clear();

        //Get inventory from the database object
        inventoryItems = database.inventoryItems;

        //populate rows and columns
        int i = 0;

        for (int row = 0; row < yPositions.Length; row++)
        {
            for (int col = 0; col < xPositions.Length; col++)
            {
                if (i >= inventoryItems.Count) return;

                if (inventoryItems[i] != null)
                {
                    ItemData item = inventoryItems[i];
                    GameObject button = Instantiate(inventoryPrefab, panel);

                    // Position relative to parent
                    RectTransform rt = button.GetComponent<RectTransform>();
                    rt.anchoredPosition = new Vector2(xPositions[col], yPositions[row]);

                    button.GetComponent<InventoryItemUI>().Setup(inventoryItems[i]);

                    i++;
                }
                else
                {
                    //Stops if inventoryItems[i] doesn't exist
                    return;
                }
            }
        }
    }
}
