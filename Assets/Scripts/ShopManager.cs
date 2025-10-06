using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [Header("Items sold in this shop")]
    public List<ItemData> shopItems;

    [Header("UI References")]
    public GameObject itemButtonPrefab;  // The UI button prefab
    public Transform itemListParent;     // The UI container to place them in

    private void Start()
    {
        PopulateShop();
    }

    void PopulateShop()
    {
        foreach (ItemData item in shopItems)
        {
            GameObject newButton = Instantiate(itemButtonPrefab, itemListParent);
            ShopItemUI ui = newButton.GetComponent<ShopItemUI>();
            ui.Setup(item);
        }
    }
}
