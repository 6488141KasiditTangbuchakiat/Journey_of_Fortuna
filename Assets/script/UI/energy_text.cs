using TMPro;
using UnityEngine;

public class energy_text : MonoBehaviour
{
    public TextMeshProUGUI textmeshPro;

    public statistics player_stats;

    int energy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        energy = player_stats.energy;

        textmeshPro.SetText($"Energy: {energy}");
    }
}
