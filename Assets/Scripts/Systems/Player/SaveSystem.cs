using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static PlayerProfile;
using UnityEngine.Profiling;

public class SaveSystem : MonoBehaviour
{
    private static string SavePath => Path.Combine(Application.persistentDataPath, "PlayerProfile.json");

    public static void SaveProfile(PlayerProfile profile)
    {
        try
        {
            string json = JsonUtility.ToJson(profile, true);
            File.WriteAllText(SavePath, json);
            Debug.Log($"Saved profile to: {SavePath}");
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Save failed: " + ex);
        }
    }

    public static PlayerProfile LoadProfile()
    {
        try
        {
            if (!File.Exists(SavePath))
            {
                Debug.Log("No existing profile — returning new default.");
                return new PlayerProfile();
            }

            string json = File.ReadAllText(SavePath);
            return JsonUtility.FromJson<PlayerProfile>(json);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Load failed: " + ex);
            return new PlayerProfile();
        }
    }
    public static bool SaveExists() => File.Exists(SavePath);
}
