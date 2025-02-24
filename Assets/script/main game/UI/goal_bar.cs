using TMPro;
using UnityEngine;

public class goal_bar : MonoBehaviour
{
    public statistics player;

    public TextMeshProUGUI goal_text;
    public TextMeshProUGUI goal_text2;
    public TextMeshProUGUI goal_text3;
    public TextMeshProUGUI goal_text4;
    public TextMeshProUGUI goal_text5;

    public int money_goal = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.myJob != null)
        {
            // have money
            money_goal = player.myJob.job_expense * 2 * 37;
            goal_text.SetText($"{player.money}/{money_goal}");

            if(player.money >= money_goal)
            {
                goal_text.SetText($"{money_goal}/{money_goal}");
            }

            // car
            if (player.hasCar)
            {
                goal_text2.SetText($"เหลือหนี้ {player.car_debt}");
            }
            else
            {
                goal_text2.SetText($"ยังไม่เป็นเจ้าของ");
            }


            // house
            if (player.hasHouse)
            {
                goal_text3.SetText($"เหลือหนี้ {player.house_debt}");
            }
            else
            {
                goal_text3.SetText($"ยังไม่เป็นเจ้าของ");
            }


            // insurance
            goal_text4.SetText($"{player.insurance_day_count}/40");

            if(player.insurance_day_count >= 40)
            {
                goal_text4.SetText($"40/40");
            }


            // p fund
            goal_text5.SetText($"{player.p_fund}/10000");

            if(player.p_fund >= 10000)
            {
                goal_text5.SetText($"10000/10000");
            }
        }

    }
}
