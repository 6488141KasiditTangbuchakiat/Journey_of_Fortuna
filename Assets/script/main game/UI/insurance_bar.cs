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
            life.SetText($"ทำประกันแล้ว");
        }
        else
        {
            life.SetText($"ยังไม่ได้ทำประกัน");
        }

        if(player.Accident_insurance.Count > 0)
        {
            string accident_in = player.Accident_insurance[0].InTier.ToString();
            accident.SetText($"ทำประกันแล้ว");
        }
        else
        {
            accident.SetText($"ยังไม่ได้ทำประกัน");
        }

        if (player.Health_insurance.Count > 0)
        {
            string health_in = player.Health_insurance[0].InTier.ToString();
            health.SetText($"ทำประกันแล้ว");
        }
        else
        {
            health.SetText($"ยังไม่ได้ทำประกัน");
        }
    }
}
