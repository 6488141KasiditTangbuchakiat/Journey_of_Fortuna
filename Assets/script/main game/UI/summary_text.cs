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

    int money_goal = 0;
    int money_percent = 0;

    int car_percent = 0;
    int house_percent = 0;


    int insur_percent = 0;
    int pfund_percent = 0;


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
            money_goal = player.myJob.job_expense * 2 * 37;
            money_percent = (player.money * 100) / money_goal;

            money_text.SetText($"{money_percent}%");

            // car

            if (player.hasCar)
            {
                car_percent = (player.car_debt * 50) / car.mortgage;
                car_percent = 50 - car_percent;
                car_percent = car_percent + 50;

                if (player.car_debt > 0 && car_percent == 100)
                {
                    car_text.SetText("99%");
                }
                else
                {
                    car_text.SetText($"{car_percent}%");
                }

            }
            else
            {
                car_text.SetText("0%");
            }

            // house

            if (player.hasHouse)
            {
                house_percent = (player.house_debt * 50) / house.mortgage;
                house_percent = 50 - house_percent;
                house_percent = house_percent + 50;

                if (player.house_debt > 0 && house_percent == 100)
                {
                    house_text.SetText("99%");
                }
                else
                {
                    house_text.SetText($"{house_percent}%");
                }

            }
            else
            {
                house_text.SetText("0%");
            }

            // insurance

            insur_percent = (player.insurance_day_count * 100) / 40;

            if(insur_percent > 100)
            {
                insur_text.SetText("100%");
            }
            else
            {
                insur_text.SetText($"{insur_percent}%");
            }

            //pfund

            pfund_percent = (player.p_fund * 100) / 10000;

            if (pfund_percent > 100)
            {
                pfund_text.SetText("100%");
            }
            else
            {
                pfund_text.SetText($"{pfund_percent}%");
            }
        }
    }
}
