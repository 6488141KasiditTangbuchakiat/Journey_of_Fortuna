using TMPro;
using UnityEngine;

public class topleft_text : MonoBehaviour
{
    private SaveManager saveManager;

    public TextMeshProUGUI energy_text;
    public TextMeshProUGUI money_text;
    public TextMeshProUGUI reserve_money_text;
    public TextMeshProUGUI name_text;

    public GameObject boy;
    public GameObject girl;

    public GameObject energy_bar;
    public float bar_location_x;
    public float bar_location_x_empty;
    public float bar_length;
    float bar_position_now;
    public float final_x;

    public statistics player_stats;

    int energy;
    int energy_cap;
    int money;
    int reserve;

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

            name_text.SetText($"{p_name}");

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

            bar_location_x = energy_bar.transform.localPosition.x;
            bar_length = Mathf.Abs(bar_location_x - bar_location_x_empty);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        energy = player_stats.energy;
        energy_cap = player_stats.energy_cap;
        energy_text.SetText($"{energy}/{energy_cap}");

        money = player_stats.money;
        money_text.SetText($"{money.ToString("N0")}");

        reserve = player_stats.reserve_money;
        reserve_money_text.SetText($"{reserve.ToString("N0")}");

        calculate_energy_bar();
    }

    public void calculate_energy_bar()
    {
        bar_position_now = (float)energy / (float)energy_cap;

        final_x = bar_location_x_empty + (bar_position_now * bar_length);

        energy_bar.transform.localPosition = new Vector3(final_x, energy_bar.transform.localPosition.y, energy_bar.transform.localPosition.z);
    }
}
