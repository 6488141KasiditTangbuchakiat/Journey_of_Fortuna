using UnityEngine;

public class house_buy : MonoBehaviour
{
    public statistics player;

    public house_panel house_panel;

    public GameObject houseBuy;
    public GameObject carBuy;

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


    }

    public void buy_house()
    {
        player.loseMoney(house_panel.house1.down_cost);
        player.addHouseDebt(house_panel.house1.mortgage);

        player.hasHouse = true;
    }

    public void buy_car()
    {
        player.loseMoney(house_panel.car1.down_cost);
        player.addCarDebt(house_panel.car1.mortgage);

        player.hasCar = true;
    }
}
