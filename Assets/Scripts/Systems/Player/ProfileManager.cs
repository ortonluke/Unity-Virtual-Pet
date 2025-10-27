using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using static PlayerProfile;

public class ProfileManager : MonoBehaviour
{
    public static ProfileManager Instance { get; private set; }
    public PlayerProfile CurrentProfile { get; private set; }

    //autosave behaviour:
    public bool autoSaveOnQuit = true;

    [SerializeField]
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
        
    }

    public void LoadAndApplyProfile()
    {
        //Load Profile
        CurrentProfile = SaveSystem.LoadProfile();

        //Apply to Runtime
        ApplyProfileToRuntime();

        //Load Inventory
        LoadInventoryFromProfile(CurrentProfile);

        
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

    private List<ItemSave> SerializeInventory(List<ItemData> runtimeInventory)
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
    public void LoadInventoryFromProfile(PlayerProfile profile)
    {
        // Clear any previous runtime inventory
        database.inventoryItems.Clear();

        foreach (var itemSave in profile.inventory)
        {
            ItemData baseItem = database.GetItemByName(itemSave.itemID);
            if (baseItem != null)
            {
                // Create a runtime copy (clone) so the original asset stays intact
                ItemData runtimeItem = ScriptableObject.Instantiate(baseItem);
                runtimeItem.quantity = itemSave.quantity;
                database.inventoryItems.Add(runtimeItem);

                Debug.Log($"Loaded {runtimeItem.itemName} with quantity {runtimeItem.quantity}");
            }
        }
    }
}
