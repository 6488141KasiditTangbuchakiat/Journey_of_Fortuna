using TMPro;
using UnityEngine;

public class topleft_text : MonoBehaviour
{
    public TextMeshProUGUI energy_text;
    public TextMeshProUGUI money_text;

    public statistics player_stats;

    int energy;
    int money;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

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
