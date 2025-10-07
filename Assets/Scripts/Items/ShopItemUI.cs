using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopItemUI : MonoBehaviour
{
    //[SerializeField] private UnityEngine.UI.Image icon;
    //[SerializeField] private TMP_Text itemNameText;
    [SerializeField] private TMP_Text priceText;

    private ItemData itemData;

    [SerializeField] private GameObject BuyPopupPrefab;

    private static GameObject buyMenu;
    [SerializeField] private float buyMenuYOffset;


    public void Setup(ItemData data)
    {
        itemData = data;
        //icon.sprite = data.icon;
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
