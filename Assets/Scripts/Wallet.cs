using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private int money;

    private StatManager statM; 

    // Start is called before the first frame update
    void Start()
    {
        statM = GameObject.Find("GameManager").GetComponent<StatManager>();

        money = statM.money;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = ": " + statM.money;
    }
}
