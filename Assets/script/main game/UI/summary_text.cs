using TMPro;
using UnityEngine;

public class summary_text : MonoBehaviour
{
    public statistics player;

    public car car;
    public house house;

    public TextMeshProUGUI money_text;
    public TextMeshProUGUI car_text;
    public TextMeshProUGUI house_text;
    public TextMeshProUGUI insur_text;
    public TextMeshProUGUI pfund_text;

    public GameObject icon1;
    public GameObject icon2;
    public GameObject icon3;
    public GameObject icon4;
    public GameObject icon5;

    int money_goal = 0;


    int p_fund_cap = 50000;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.myJob != null)
        {
            //  money
            money_goal = player.myJob.all_expense() * 2 * 37;

            money_text.SetText($"{player.money.ToString("N0")}/{money_goal.ToString("N0")}");

            if (player.money > money_goal)
            {
                money_text.SetText($"{money_goal.ToString("N0")}/{money_goal.ToString("N0")}");
                icon1.SetActive(true);
            }

            // car

            if (player.hasCar != null)
            {

                car_text.SetText($"เหลือ {player.car_debt.ToString("N0")}");

                if (player.car_debt == 0)
                {
                    car_text.SetText($"ผ่อนรถหมดแล้ว");
                    icon2.SetActive(true);
                }

            }
            else
            {
                car_text.SetText("ยังไม่เป็นเจ้าของ");
            }

            // house

            if (player.hasHouse != null)
            {

                house_text.SetText($"เหลือ {player.house_debt.ToString("N0")}");

                if (player.house_debt == 0)
                {
                    house_text.SetText($"ผ่อนบ้านหมดแล้ว");
                    icon3.SetActive(true);
                }
            }
            else
            {
                house_text.SetText("ยังไม่เป็นเจ้าของ");
            }

            // insurance

            insur_text.SetText($"{player.insurance_day_count}/40");

            if (player.insurance_day_count >= 40)
            {
                insur_text.SetText($"40/40");
                icon4.SetActive(true);
            }


            //pfund


            pfund_text.SetText($"{player.p_fund.ToString("N0")}/{p_fund_cap.ToString("N0")}");

            if(player.p_fund >= p_fund_cap)
            {
                pfund_text.SetText($"{p_fund_cap.ToString("N0")}/{p_fund_cap.ToString("N0")}");
                icon5.SetActive(true);
            }

        }
    }
}
