using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager: MonoBehaviour
{
    [SerializeField] public float hunger;
    [SerializeField] public float mood;
    [SerializeField] public float energy;
    [SerializeField] public int money;

    public string playerName;
    [SerializeField] private float hungerDrainAmount = 0.1f;
    [SerializeField] private float moodDrainAmount = 0.1f;
    [SerializeField] private float energyDrainAmount = 0.1f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            updateHunger(-hungerDrainAmount);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            updateMood(-moodDrainAmount);
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            updateEnergy(-energyDrainAmount);
        }
    }
    private float updateStat(float oldStat, float x)
    {
        if (oldStat + x >= 1)
        {
            return 1;
        }
        else if (oldStat + x <= 0)
        {
            return 0;
        }
        else
        {
            return oldStat += x;
        }
    }

    public void updateHunger(float deltaStat)
    {
        hunger = updateStat(hunger, deltaStat);
    }
    public void updateMood(float deltaStat)
    {
        mood = updateStat(mood, deltaStat);
    }
    public void updateEnergy(float deltaStat)
    {
        energy = updateStat(energy, deltaStat);
    }
    public void updateMoney(int deltaMoney)
    {
        if (money + deltaMoney <= 0)
        {
            money = 0;
        }
        else
        {
            money += deltaMoney;
        }
    }
    public void ConsumeUpdate(float hunger = 0, float mood = 0, float energy = 0)
    {
        updateHunger(hunger / 100);
        updateMood(mood / 100);
        updateEnergy(energy / 100);
    }
    
}
