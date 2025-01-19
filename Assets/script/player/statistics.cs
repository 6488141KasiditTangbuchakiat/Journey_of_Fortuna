using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static partner.Job_type;

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

    public int jobless_day = 0;


    public int house_debt = 0;
    public int car_debt = 0;
    public int loan_debt = 0;

    public int insurance_cost = 0;

    public int child_payment = 0;


    // energy
    public int energy = 0;
    public int energy_cap = 100;

    // stock
    public int stock1 = 0;
    public int stock2 = 0;
    public int stock3 = 0;


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

    public void ExpenseMoney(int money_lost)
    {
        if (partner != null)
        {
            if (partner.partner_job == Accountant)
            {
                this.money -= (int)(money_lost - (money_lost * 10/100));
            }
            else
            {
                this.money -= money_lost;
            }
        }
        else
        {
            this.money -= money_lost;
        }
    }

    public void loseMoney(int money_lost)
    {
        this.money -= money_lost;
    }

    public void addSalary()
    {
        if (jobless_day == 0)
        {
            this.money += myJob.salary_on_green_tile;
        }
        else
        {
            jobless_day_pass();
        }

    }

    public void jobless_day_pass()
    {
        jobless_day--;

        if(jobless_day < 0)
        {
            jobless_day = 0;
        }
    }

    public void jobless_for_x_days(int day)
    {
        jobless_day = day;
    }



    public void addEnergy(int energy_gain)
    {
        this.energy += energy_gain;

        if (hasHouse)
        {
            this.energy++;
        }

        if (this.energy > this.energy_cap)
        {
            this.energy = this.energy_cap;
        }
    }

    public void addEnergy_disregard_house(int energy_gain)
    {
        this.energy += energy_gain;

        if (this.energy > this.energy_cap)
        {
            this.energy = this.energy_cap;
        }
    }

    public void loseEnergy(int energy_lost)
    {
        if(partner != null)
        {
            if(partner.partner_job == Athlete)
            {
                this.energy -= (int)(energy_lost / 2);
            }
            else
            {
                this.energy -= energy_lost;
            }
        }
        else
        {
            this.energy -= energy_lost;
        }

    }
    public void addInsuranceCost(int insurance_cost)
    {
        insurance_cost += insurance_cost;
    }

    public void addHouseDebt(int house)
    {
        house_debt += house;
    }

    public void addCarDebt(int car)
    {
        car_debt += car;
    }

    public void increase_love_level()
    {
        this.love_level++;
    }

    public int child_cost()
    {
        int child_num = love_level - 1;
        if (child_num < 0)
        {
            child_num = 0;
        }
        int cost = child_num * child_payment;

        return cost;
    }

    public void no_lover_again()
    {
        this.love_level = 0;
    }
}
