using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatTracker : MonoBehaviour
{
    [SerializeField] private float hunger;
    [SerializeField] private float mood;
    [SerializeField] private float energy;

    [SerializeField] private int food;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void updateFood(int x)
    {
        food += x;
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

    public float getMood()
    {
        return mood;
    }

    public float getEnergy()
    {
        return energy;
    }

    public float getHunger() 
    { 
        return hunger; 
    }
}
