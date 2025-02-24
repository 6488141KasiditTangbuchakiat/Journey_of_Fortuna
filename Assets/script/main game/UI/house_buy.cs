using System.Collections;
using TMPro;
using UnityEngine;

public class house_buy : MonoBehaviour
{
    public statistics player;

    public house_panel house_panel;

    public bool select_house = false;
    public bool select_car = false;

    public TextMeshProUGUI select_text;

    public GameObject houseBuy;
    public GameObject carBuy;
    public GameObject confirm_buy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //block buy
        if (player.money < house_panel.house1.down_cost || player.hasHouse)
        {
            houseBuy.SetActive(false);
        }
        else
        {
            houseBuy.SetActive(true);
        }

        if (player.money < house_panel.car1.down_cost || player.hasCar)
        {
            carBuy.SetActive(false);
        }
        else
        {
            carBuy.SetActive(true);
        }


        if (select_house || select_car)
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


    }

    public void buy_house()
    {
        player.loseMoney(house_panel.house1.down_cost);
        player.addHouseDebt(house_panel.house1.mortgage);
        select_house = false;

        player.hasHouse = true;
    }

    public void buy_car()
    {
        player.loseMoney(house_panel.car1.down_cost);
        player.addCarDebt(house_panel.car1.mortgage);
        select_car = false;

        player.hasCar = true;
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
    }

}
