using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{
    [SerializeField] private StatTracker stats; 
    [SerializeField] private RectTransform fillRect;

    [SerializeField] private float fillSpeed;

    [SerializeField] private float leftPadding = 15;

    private float initialWidth;

    private void Start()
    {
        initialWidth = fillRect.sizeDelta.x;
        fillRect.pivot = new Vector2(0f, 0.5f);
        fillRect.anchoredPosition = new Vector2(leftPadding, 0f);
    }   

    void Update()
    {
        // Calculate target width based on hunger
        float targetWidth = stats.getHunger() * initialWidth;

        // Smoothly slide width
        float newWidth = Mathf.Lerp(fillRect.sizeDelta.x, targetWidth, Time.deltaTime * fillSpeed);
        fillRect.sizeDelta = new Vector2(newWidth, fillRect.sizeDelta.y);

    }
}
