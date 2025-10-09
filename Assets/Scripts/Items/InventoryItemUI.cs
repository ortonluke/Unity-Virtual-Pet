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

    public void ButtonPressed()
    {
        Debug.Log("Inventory (" + itemData.name + ") pressed!");
        /*
        //Make popup menu show up
        if (buyMenu == null)
        {
            buyMenu = Instantiate(BuyPopupPrefab, transform.parent.parent);
            buyMenu.GetComponent<BuyPopup>().SetShopItem(this);
            buyMenu.transform.localPosition = new Vector3(0, buyMenuYOffset, 0);
        }
        */
    }
}
