using System.IO;
using UnityEngine;

public class SoundSaveManager : MonoBehaviour
{
    private string saveFilePath;

    void Awake()
    {
        saveFilePath = Application.persistentDataPath + "/soundData.json";
    }

    // Save data to file
    public void SaveSound(SoundData data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(saveFilePath, json);
        Debug.Log("Sound Saved to: " + saveFilePath);
    }

    // Load data from file
    public SoundData LoadSound()
    {
        Debug.Log("Loaded from: " + saveFilePath);

        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            SoundData loadedData = JsonUtility.FromJson<SoundData>(json);
            Debug.Log("Sound Loaded");
            return loadedData;
        }
        else
        {
            Debug.LogWarning("No Sound file found!");
            return null; // Return null or a default SaveData if no file exists
        }
    }

    public void DeleteSound()
    {
        if (File.Exists(saveFilePath))
        {
            File.Delete(saveFilePath);
            Debug.Log("Sound file deleted.");
        }
        else
        {
            Debug.Log("No Sound file found to delete.");
        }
    }
}
