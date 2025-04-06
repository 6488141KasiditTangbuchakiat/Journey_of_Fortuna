using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    private string saveFilePath;
    private slot_saving slot_number;
    
    void Awake()
    {
        slot_number  = Object.FindFirstObjectByType<slot_saving>();

        save_slot data = slot_number.load_slot();

        int number = data.player_num;

        print("slot is " + number);

        saveFilePath = Application.persistentDataPath + "/savefile_" + number + ".json";
    }

    // Save data to file
    public void SaveGame(SaveData data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(saveFilePath, json);
        Debug.Log("Game Saved to: " + saveFilePath);
    }

    // Load data from file
    public SaveData LoadGame()
    {
        Debug.Log("Loaded from: " + saveFilePath);

        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            SaveData loadedData = JsonUtility.FromJson<SaveData>(json);
            Debug.Log("Game Loaded");
            return loadedData;
        }
        else
        {
            Debug.LogWarning("No save file found!");
            return null; // Return null or a default SaveData if no file exists
        }
    }

    public void DeleteSaveFile()
    {
        if (File.Exists(saveFilePath))
        {
            File.Delete(saveFilePath);
            Debug.Log("Save file deleted.");
        }
        else
        {
            Debug.Log("No save file found to delete.");
        }
    }

}