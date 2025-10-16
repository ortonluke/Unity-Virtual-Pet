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
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            stats.updateMood(-moodDrainAmount);
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            stats.updateEnergy(-energyDrainAmount);
        }
    }
    public void updateMoney(int x)
    {
        money += x;
    }

    public void ConsumeUpdate(float hunger = 0, float mood = 0, float energy = 0)
    {
        stats.updateHunger(hunger / 100);
        stats.updateMood(mood / 100);
        stats.updateEnergy(energy / 100);
    }
}
