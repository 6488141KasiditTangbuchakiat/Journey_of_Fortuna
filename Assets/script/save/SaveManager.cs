using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    private string saveFilePath;

    void Awake()
    {
        saveFilePath = Application.persistentDataPath + "/savefile.json";
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
}