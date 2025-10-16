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

    private StatManager statM;

    [SerializeField] private TextMeshProUGUI stat1Text;
    [SerializeField] private TextMeshProUGUI stat2Text;
    [SerializeField] private TextMeshProUGUI stat3Text;

    // Start is called before the first frame update
    void Start()
    {
        itemData = shopItem.GetItemData();
        statM = GameObject.Find("GameManager").GetComponent<StatManager>();

        titleText.text = itemData.name;
        descText.text = itemData.description;

        slider.minValue = 0;
        slider.maxValue = itemData.buyMaxNum;

        database = FindObjectOfType<ItemDatabase>();

        SetStatistics();
    }

    // Update is called once per frame
    void Update()
    {
        numSelected.text = "Buy: " + slider.value.ToString() + ", Cost: " + (slider.value * itemData.price).ToString();
    }

    public void SetShopItem(ShopItemUI creator)
    {
        shopItem = creator;
    }

    private void SetStatistics()
    {
        if (itemData.typeName == "Food")
        {
            stat1Text.text = "Hunger: " + (itemData.stat1 > 0 ? "+" : "") + itemData.stat1;
            stat1Text.color = new Color32(255, 174, 66, 255);

            stat2Text.text = "Mood: " + (itemData.stat2 > 0 ? "+" : "") + itemData.stat2;
            stat2Text.color = new Color32(129, 250, 124, 255);

            stat3Text.text = "Energy: " + (itemData.stat3 > 0 ? "+" : "") + itemData.stat3;
            stat3Text.color = new Color32(76, 243, 255, 255);
        }
    }


    public void Purchase()
    {
        if (slider.value > 0)
        {
            if (statM.money >= itemData.price * (int)slider.value)
            {
                //Purchase Accepted
                itemData.quantity += (int)slider.value;
                database.AddToInventory(itemData);
                shopItem.createAlert("Purchased!", Color.green);
                statM.updateMoney(itemData.price * -1 * (int)slider.value);
                Destroy(gameObject);
            }
            else
            {
                //Purchase Denied
                shopItem.createAlert("Insufficient Funds!", Color.red);
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
