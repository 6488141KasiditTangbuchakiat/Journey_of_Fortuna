using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.SceneManagement;

public class continue_display : MonoBehaviour
{
    public TextMeshProUGUI cont1;

    private string saveFilePath;
    public int slot_num;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        saveFilePath = Application.persistentDataPath + "/savefile_" + slot_num + ".json";

        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            SaveData loadedData = JsonUtility.FromJson<SaveData>(json);
            Debug.Log("Game Loaded");

            cont1.SetText(loadedData.player_name);
        }
        else
        {
            Debug.LogWarning("No save file found!");

            cont1.SetText("no save file");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void load_the_save()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            SaveData loadedData = JsonUtility.FromJson<SaveData>(json);

            int stage_num = loadedData.save_player_stage;

            if(stage_num > 1)
            {
                SceneManager.LoadScene($"mainGame {stage_num}");
            }
            else
            {
                SceneManager.LoadScene($"mainGame");
            }
        }
    }
}
