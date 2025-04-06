using UnityEngine;
using System.IO;

public class slot_saver : MonoBehaviour
{
    private string saveFilePath;
    void Awake()
    {

        saveFilePath = Application.persistentDataPath + "/player_slot.json";
    }

    // Save data to file
    public void SaveGame(save_slot data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(saveFilePath, json);
        Debug.Log("Game Saved to: " + saveFilePath);
    }

    // Load data from file
    public save_slot LoadGame()
    {
        Debug.Log("Loaded from: " + saveFilePath);

        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            save_slot loadedData = JsonUtility.FromJson<save_slot>(json);
            Debug.Log("Game Loaded");
            return loadedData;
        }
        else
        {
            Debug.LogWarning("No save file found!");
            return null; // Return null or a default SaveData if no file exists
        }
    }
}
