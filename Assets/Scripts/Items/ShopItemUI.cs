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

    public void Setup(ItemData data)
    {
        itemData = data;
        //icon.sprite = data.icon;
        //itemNameText.text = data.itemName;
        priceText.text = data.price.ToString() + " Gold";
    }

    public void ButtonPressed()
    {
        Debug.Log("Bought " + itemData.itemName);
    }
}
