using System.Collections;
using TMPro;
using UnityEngine;

public class house_buy : MonoBehaviour
{
    public statistics player;

    public house_panel house_panel;

    public house house1;
    public car car1;

    public bool select_house = false;
    public bool select_car = false;
    public int buy_duration = 0;

    public TextMeshProUGUI select_text;
    public TextMeshProUGUI date_text;

    public GameObject houseBuy;
    public GameObject carBuy;
    public GameObject confirm_buy;

    int max_year_limit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        max_year_limit = 60 - player.age;

        //block buy
        if (player.money < house_panel.house1.down_cost || player.hasHouse != null)
        {
            houseBuy.SetActive(false);
        }
        else
        {
            houseBuy.SetActive(true);
        }

        if (player.money < house_panel.car1.down_cost || player.hasCar != null)
        {
            carBuy.SetActive(false);
        }
        else
        {
            carBuy.SetActive(true);
        }


        if ((select_house || select_car) && buy_duration > 0)
        {
            confirm_buy.SetActive(true);
        }
        else
        {
            confirm_buy.SetActive(false);
        }

        // text change
        string text = "คุณเลือกซื้อ: ";

        if (select_house == false && select_car == false)
        {
            text = text + "";
        }
        else
        {
            if (select_house)
            {
                text = text + "บ้าน";
            }

            if (select_car)
            {
                if (select_house)
                {
                    text = text + ", ";
                }
                text = text + "รถ";
            }
        }

        select_text.SetText(text);

        date_text.SetText($"จำนวนปีที่เลือกผ่อน: {buy_duration} ปี");


    }

    public void buy_house()
    {
        player.loseMoney(house_panel.house1.down_cost);
        player.addHouseDebt(house_panel.house1.mortgage);
        player.house_payment_time = buy_duration;
        select_house = false;

        player.hasHouse = house1;
    }

    public void buy_car()
    {
        player.loseMoney(house_panel.car1.down_cost);
        player.addCarDebt(house_panel.car1.mortgage);
        player.car_payment_time = buy_duration;
        select_car = false;

        player.hasCar = car1;
    }

    public void choose_house()
    {
        select_house = !select_house;
    }

    public void choose_car()
    {
        select_car = !select_car;
    }

    public void final_buy()
    {
        if (select_house)
        {
            buy_house();
        }

        if (select_car)
        {
            buy_car();
        }

        buy_duration = 0;
    }

    public void increase_date()
    {
        if (buy_duration < max_year_limit)
        {
            buy_duration++;
        }
        else
        {
            buy_duration = max_year_limit;
        }

    }

    public void decrease_date()
    {
        if (buy_duration > 0)
        {
            buy_duration--;
        }
        else
        {
            buy_duration = 0;
        }
    }
}
