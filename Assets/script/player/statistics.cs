using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statistics : MonoBehaviour
{
    [SerializeField]

    // my life

    public int age;
    public int player_stage = 0;
    public job myJob;

    public bool hasHouse;
    public bool hasCar;

    public partner partner;
    public int love_level = 0;

    // money stats + payment
    public int money = 0;

    

    public int house_debt = 0;
    public int car_debt = 0;
    public int creditcard_debt = 0;

    public int insurance_cost = 0;


    // energy
    public int energy = 0;
    public int energy_cap = 100;

    // stock
    public int stock_price = 0;


    // insurance
    public bool life_insurance = false;

    public List<insurance> Accident_insurance = new List<insurance>();
    public List<insurance> Health_insurance = new List<insurance>();

    // Start is called before the first frame update
    void Start()
    {
        age = 14;
        energy_cap = 50;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    public void addMoney(int money_gain)
    {
        this.money += money_gain;
    }

    public void reduceMoney(int money_lost)
    {
        this.money -= money_lost;
    }

    public void addSalary()
    {
        this.money += myJob.salary_on_green_tile;
    }



    public void addEnergy(int energy_gain)
    {
        this.energy += energy_gain;

        if (this.energy > this.energy_cap)
        {
            this.energy = this.energy_cap;
        }
    }

    public void addInsuranceCost(int insurance_cost)
    {
        insurance_cost += insurance_cost;
    }

    public void stockpriceChange(int changed_price)
    {
        this.stock_price = changed_price;
    }

    public void increase_love_level()
    {
        this.love_level++;
    }
}
