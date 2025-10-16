using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class InventoryItemUI : MonoBehaviour
{
    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private UnityEngine.UI.Image render;

    private ItemData itemData;

    [SerializeField] private GameObject invPopup;


    //Popup Prefab for selecting it

    public void Setup(ItemData data)
    {
        itemData = data;
        if (data.icon != null)
        {
            render.sprite = data.icon;
        }

        quantityText.text = itemData.quantity.ToString();
    }
    public ItemData GetItemData()
    {
        return itemData;
    }
    private int GetStock()
    {
        return itemData.buyMaxNum;
    }

    public void ButtonPressed()
    {
        GameObject menu = Instantiate(invPopup, transform.parent);
        menu.GetComponent<ConsumePopup>().SetShopItem(this);
    }
}
