using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private int money;
    [SerializeField] private int startMoney;

    // Start is called before the first frame update
    void Start()
    {
        money = startMoney;
        text.text = ": " + money;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateMoney(int x)
    {
        money += x;
        text.text = ": " + money;    
    }
}
