using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ShopItemUI : MonoBehaviour
{
    [SerializeField] private TMP_Text priceText;
    [SerializeField] private UnityEngine.UI.Image render;

    private ItemData itemData;

    [SerializeField] private GameObject BuyPopupPrefab;

    private static GameObject buyMenu;
    [SerializeField] private float buyMenuYOffset;

    public void Setup(ItemData data)
    {
        itemData = data;
        if (data.icon != null)
        {
            Debug.Log("I HAVE AN ICON");
            render.sprite = data.icon;
        }
        else
        {
            Debug.Log("I DON'T HAVE AN ICON");
        }

            //itemNameText.text = data.itemName;
            priceText.text = data.price.ToString() + " Gold";
    }

    public void ButtonPressed()
    {
        //Make popup menu show up
        if (buyMenu == null)
        {
            buyMenu = Instantiate(BuyPopupPrefab, transform.parent.parent);
            buyMenu.GetComponent<BuyPopup>().SetShopItem(this);
            buyMenu.transform.localPosition = new Vector3(0, buyMenuYOffset, 0);
        }
    }

    public ItemData GetItemData()
    {
        return itemData;
    }

}
