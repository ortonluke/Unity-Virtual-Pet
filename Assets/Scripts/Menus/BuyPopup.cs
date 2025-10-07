using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuyPopup : MonoBehaviour
{
    private ShopItemUI shopItem;

    private ItemData itemData;

    [SerializeField] private TextMeshProUGUI titleText;
    // Start is called before the first frame update
    void Start()
    {
        itemData = shopItem.GetItemData();
        titleText.text = itemData.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetShopItem(ShopItemUI creator)
    {
        shopItem = creator;
    }

    public void Purchase()
    {
        Debug.Log("Purchased: " + itemData.name);
    }
}
