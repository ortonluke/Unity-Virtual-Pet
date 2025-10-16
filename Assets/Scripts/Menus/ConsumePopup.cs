using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConsumePopup : MonoBehaviour
{
    private InventoryItemUI invItem;

    private ItemData itemData;

    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descText;
    [SerializeField] private TextMeshProUGUI numSelected;

    [SerializeField] private UnityEngine.UI.Slider slider;

    private ItemDatabase database;

    private StatManager statM;

    [SerializeField] private TextMeshProUGUI stat1Text;
    private float stat1;

    [SerializeField] private TextMeshProUGUI stat2Text;
    private float stat2;

    [SerializeField] private TextMeshProUGUI stat3Text;
    private float stat3;

    // Start is called before the first frame update
    void Start()
    {
        itemData = invItem.GetItemData();
        statM = GameObject.Find("GameManager").GetComponent<StatManager>();

        titleText.text = itemData.name;
        descText.text = itemData.description;

        slider.minValue = 0;
        slider.maxValue = itemData.quantity;

        database = FindObjectOfType<ItemDatabase>();

        SetStats();
    }

    // Update is called once per frame
    void Update()
    {
        numSelected.text = "Use: " + slider.value;
    }

    private void SetStats()
    {
        stat1Text.text = "Hunger: " + (itemData.stat2 > 0 ? "+" : "") + itemData.stat1;
        stat1Text.color = new Color32(255, 174, 66, 255);

        stat2Text.text = "Mood: " + (itemData.stat2 > 0 ? "+" : "") + itemData.stat2;
        stat2Text.color = new Color32(129, 250, 124, 255);

        stat3Text.text = "Energy: " + (itemData.stat2 > 0 ? "+" : "") + itemData.stat3;
        stat3Text.color = new Color32(76, 243, 255, 255);
    }

    public void Use()
    {

    }

    public void SetShopItem(InventoryItemUI creator)
    {
        invItem = creator;
    }
}
