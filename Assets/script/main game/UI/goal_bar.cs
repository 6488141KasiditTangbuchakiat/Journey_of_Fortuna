using TMPro;
using UnityEngine;

public class goal_bar : MonoBehaviour
{
    public statistics player;

    public TextMeshProUGUI goal_text;
    public TextMeshProUGUI goal_text1_1;
    public TextMeshProUGUI goal_text2;
    public TextMeshProUGUI goal_text3;
    public TextMeshProUGUI goal_text4;
    public TextMeshProUGUI goal_text5;

    public int money_goal = 0;
    public int all_money = 0;
    int reserve_cap = 2;
    public int insurance_day_cap = 20;
    public int p_fund_cap = 50000;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.myJob != null)
        {
            if (player.myJob.name == "kid")
            {
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);


                // have money
                money_goal = player.myJob.all_expense();

                if (player.hasCar != null)
                {
                    money_goal -= player.myJob.job_expense_travel;
                }

                if (player.hasHouse != null)
                {
                    money_goal -= player.myJob.job_expense_housing;
                }

                money_goal = money_goal * 12 * 37;

                all_money = player.money + player.reserve_money;

                goal_text.SetText($"{all_money.ToString("N0")}/{money_goal.ToString("N0")}");

                if (all_money >= money_goal)
                {
                    goal_text.SetText($"{money_goal.ToString("N0")}/{money_goal.ToString("N0")}");
                }

                // reserve money
                goal_text1_1.SetText($"{player.reserve_threshold_reached}/{reserve_cap}");

                if (player.reserve_threshold_reached >= reserve_cap)
                {
                    goal_text1_1.SetText($"{reserve_cap}/{reserve_cap}");
                }


                // car
                if (player.hasCar != null)
                {
                    goal_text2.SetText($"เหลือหนี้ {player.car_debt.ToString("N0")}");
                }
                else
                {
                    goal_text2.SetText($"ยังไม่เป็นเจ้าของ");
                }


                // house
                if (player.hasHouse != null)
                {
                    goal_text3.SetText($"เหลือหนี้ {player.house_debt.ToString("N0")}");
                }
                else
                {
                    goal_text3.SetText($"ยังไม่เป็นเจ้าของ");
                }


                // insurance
                goal_text4.SetText($"{player.insurance_day_count}/{insurance_day_cap}");

                if (player.insurance_day_count >= insurance_day_cap)
                {
                    goal_text4.SetText($"{insurance_day_cap}/{insurance_day_cap}");
                }


                // p fund
                goal_text5.SetText($"{player.p_fund.ToString("N0")}/{p_fund_cap.ToString("N0")}");

                if (player.p_fund >= p_fund_cap)
                {
                    goal_text5.SetText($"{p_fund_cap.ToString("N0")}/{p_fund_cap.ToString("N0")}");
                }
            }



        }

    }
}
