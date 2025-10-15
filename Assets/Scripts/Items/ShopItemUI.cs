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
    [SerializeField] private TextMeshProUGUI alertText;


    private ItemData itemData;

    [SerializeField] private GameObject BuyPopupPrefab;
    private static GameObject buyMenu;
    [SerializeField] private float buyMenuYOffset;

    public int stock;



    public void Setup(ItemData data)
    {
        itemData = data;
        if (data.icon != null)
        {
            render.sprite = data.icon;
        }
        else
        {
            
        }
        priceText.text = data.price.ToString() + " Gold";

        stock = GetStock();

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

    private int GetStock()
    {
        return itemData.buyMaxNum;
    }

    public ItemData GetItemData()
    {
        return itemData;
    }

    public void createAlert(string text, Color color, float duration = 4f)
    {
        //Vector2 alertPosition = new Vector2(0, 0);
        if (alertText == null)
        {
            Debug.Log("Text prefab not assigned!");
            return;
        }

        // Instantiate the text as a child of the canvas
        TextMeshProUGUI tmp = Instantiate(alertText, gameObject.transform.parent.parent);

        // Set text and color
        tmp.text = text;
        tmp.color = color;

        // Start fade out coroutine
        StartCoroutine(FadeText(tmp, duration));
    }

    private IEnumerator FadeText(TextMeshProUGUI tmp, float duration)
    {
        float elapsed = 0f;
        Color originalColor = tmp.color;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsed / duration);
            tmp.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        // Destroy the text after fading
        Destroy(tmp.gameObject);
    }
}
