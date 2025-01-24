using TMPro;
using UnityEngine;

public class insurance_bar : MonoBehaviour
{
    public statistics player;

    public TextMeshProUGUI life;
    public TextMeshProUGUI accident;
    public TextMeshProUGUI health;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.life_insurance)
        {
            life.SetText($"Owned");
        }
        else
        {
            life.SetText($"Not owned");
        }

        if(player.Accident_insurance.Count > 0)
        {
            string accident_in = player.Accident_insurance[0].InTier.ToString();
            accident.SetText($"{accident_in} rank");
        }
        else
        {
            accident.SetText($"Not owned");
        }

        if (player.Health_insurance.Count > 0)
        {
            string health_in = player.Health_insurance[0].InTier.ToString();
            health.SetText($"{health_in} rank");
        }
        else
        {
            health.SetText($"Not owned");
        }
    }
}
