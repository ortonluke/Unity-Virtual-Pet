using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class BuyPopup : MonoBehaviour
{
    private ShopItemUI shopItem;

    private ItemData itemData;

    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descText;
    [SerializeField] private TextMeshProUGUI numSelected;

    [SerializeField] private UnityEngine.UI.Slider slider;

    private ItemDatabase database;

    // Start is called before the first frame update
    void Start()
    {
        itemData = shopItem.GetItemData();

        titleText.text = itemData.name;
        descText.text = itemData.description;

        slider.minValue = 0;
        slider.maxValue = itemData.buyMaxNum;

        database = FindObjectOfType<ItemDatabase>();
    }

    // Update is called once per frame
    void Update()
    {
        numSelected.text = slider.value.ToString();
    }

    public void SetShopItem(ShopItemUI creator)
    {
        shopItem = creator;
    }

    public void Purchase()
    {
        Debug.Log("Purchased: " + itemData.name);
        //Get InventoryItemUI and add quantity there
        itemData.quantity += (int) slider.value;
        database.AddToInventory(itemData);
        Destroy(gameObject);
    }
}
