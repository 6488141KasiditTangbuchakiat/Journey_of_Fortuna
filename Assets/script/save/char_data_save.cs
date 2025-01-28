using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class char_data_save : MonoBehaviour
{
    private SaveManager saveManager;

    public TextMeshProUGUI name_text;
    public select_boy_girl myGender;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        saveManager = Object.FindFirstObjectByType<SaveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void savePlayer()
    {
        saveManager.DeleteSaveFile();

        SaveData data = new SaveData
        {
            player_gender = myGender.gender,
            player_name = name_text.text,
        };

        saveManager.SaveGame(data);
    }
}
