using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private GameObject menuPrefab;
    private GameObject menu;

    private UnityEngine.UI.Button button;

    private GameObject parentObject;

    private void Start()
    {
        parentObject = this.transform.parent.gameObject;
    }
    public void ButtonPressed()
    {
        if (menu == null)
        {
            menu = Instantiate(menuPrefab, parentObject.transform);
            menu.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        }
    }
}
