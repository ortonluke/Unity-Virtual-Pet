using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoodBar : MonoBehaviour
{
    [SerializeField] private StatManager stats;
    [SerializeField] private RectTransform fillRect;

    [SerializeField] private float fillSpeed;

    [SerializeField] private float leftPadding = 15;

    private float initialWidth;

    private void Start()
    {
        stats = FindObjectOfType<StatManager>();

        initialWidth = fillRect.sizeDelta.x;
        fillRect.pivot = new Vector2(0f, 0.5f);
        fillRect.anchoredPosition = new Vector2(leftPadding, 0f);
    }

    void Update()
    {
        // Calculate target width based on hunger
        float targetWidth = stats.mood * initialWidth;

        // Smoothly slide width
        float newWidth = Mathf.Lerp(fillRect.sizeDelta.x, targetWidth, Time.deltaTime * fillSpeed);
        fillRect.sizeDelta = new Vector2(newWidth, fillRect.sizeDelta.y);

    }
}
