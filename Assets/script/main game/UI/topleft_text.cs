using TMPro;
using UnityEngine;

public class topleft_text : MonoBehaviour
{
    private SaveManager saveManager;

    public TextMeshProUGUI energy_text;
    public TextMeshProUGUI money_text;
    public TextMeshProUGUI name_text;

    public GameObject boy;
    public GameObject girl;

    public statistics player_stats;

    int energy;
    int money;

    string p_name;
    int gender;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        saveManager = Object.FindFirstObjectByType<SaveManager>();
        SaveData loadedData = saveManager.LoadGame();

        if (loadedData != null)
        {
            p_name = loadedData.player_name;
            gender = loadedData.player_gender;

            name_text.SetText($"Name: {p_name}");

            if (loadedData.player_gender == 1)
            {
                boy.SetActive(true);
                girl.SetActive(false);
            }
            else if (loadedData.player_gender == 2)
            {
                boy.SetActive(false);
                girl.SetActive(true);
            }

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        energy = player_stats.energy;
        energy_text.SetText($"Energy: {energy}");

        money = player_stats.money;
        money_text.SetText($"Money: {money}");
    }
}
