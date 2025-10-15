using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager: MonoBehaviour
{
    [SerializeField] private StatTracker stats;
    [SerializeField] private float hungerDrainAmount = 0.1f;
    [SerializeField] private float moodDrainAmount = 0.1f;
    [SerializeField] private float energyDrainAmount = 0.1f;

    [SerializeField] public int money = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stats.updateHunger(-hungerDrainAmount);
            Debug.Log("Hunger drained! Current hunger: " + stats.getHunger());
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            stats.updateMood(-moodDrainAmount);
            Debug.Log("Mood drained! Current mood: " + stats.getMood());
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            stats.updateEnergy(-energyDrainAmount);
            Debug.Log("Energy drained! Current energy: " + stats.getEnergy());
        }
    }
    public void updateMoney(int x)
    {
        money += x;
    }
}
