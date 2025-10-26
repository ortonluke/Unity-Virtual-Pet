using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerProfile;

public class ProfileManager : MonoBehaviour
{
    public static ProfileManager Instance { get; private set; }
    public PlayerProfile CurrentProfile { get; private set; }

    //autosave behaviour:
    public bool autoSaveOnQuit = true;


    private ItemDatabase database;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadAndApplyProfile();
    }

    private void Start()
    {
        database = FindAnyObjectByType<ItemDatabase>();
        Debug.Log(Application.persistentDataPath);
    }

    public void LoadAndApplyProfile()
    {
        CurrentProfile = SaveSystem.LoadProfile();
        ApplyProfileToRuntime();
    }

    // Copy saved profile values into StatManager (the runtime component)
    public void ApplyProfileToRuntime()
    {
        StatManager stat = FindObjectOfType<StatManager>();
        if (stat == null)
        {
            Debug.LogWarning("No StatManager found in scene to apply profile to.");
            return;
        }

        stat.playerName = CurrentProfile.playerName;
        stat.money = CurrentProfile.money;
        stat.energy = CurrentProfile.energy;
        stat.mood = CurrentProfile.mood;
        stat.hunger = CurrentProfile.hunger;
    }

    // Read runtime values and put them into CurrentProfile, then save
    public void UpdateProfileFromRuntimeAndSave()
    {
        var stat = FindObjectOfType<StatManager>();
        if (stat == null)
        {
            Debug.LogWarning("No StatManager found in scene to read runtime values from.");
            return;
        }

        CurrentProfile.playerName = stat.playerName;
        CurrentProfile.money = stat.money;
        CurrentProfile.energy = stat.energy;
        CurrentProfile.mood = stat.mood;
        CurrentProfile.hunger = stat.hunger;

        CurrentProfile.inventory = SerializeInventory(database.inventoryItems);

        SaveSystem.SaveProfile(CurrentProfile);
    }

    void OnApplicationQuit()
    {
        if (autoSaveOnQuit)
            UpdateProfileFromRuntimeAndSave();
    }

    public List<ItemSave> SerializeInventory(List<ItemData> runtimeInventory)
    {
        List<ItemSave> saved = new List<ItemSave>();

        foreach (var item in runtimeInventory)
        {
            // Use the quantity stored in the ItemData itself
            saved.Add(new ItemSave
            {
                itemID = item.itemName,
                quantity = item.quantity
            });
        }

        return saved;
    }
}
