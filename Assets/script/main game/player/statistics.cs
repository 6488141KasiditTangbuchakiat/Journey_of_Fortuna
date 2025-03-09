using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static partner.Job_type;
using static Unity.VisualScripting.Metadata;

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

    public int pay_raise = 0;
    public int jobless_day = 0;

    public int p_fund = 0;
    public int p_fund_percentage = 0;
    public int p_fund_banned = 0;

    public int house_debt = 0;
    public int car_debt = 0;
    public int loan_debt = 0;
    public int borrowed_money = 0;

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

    public int insurance_day_count;

    // step taken
    public int step_taken = 0;

    // Start is called before the first frame update
    void Start()
    {
        energy_cap = 50;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    public void addMoney(int money_gain)
    {
        this.money += money_gain;

        check_debt();
    }

    public void ExpenseMoney(int money_lost)
    {
        if (partner != null)
        {
            if (partner.partner_job == Accountant)
            {
                this.money -= (int)(money_lost - (money_lost * 10 / 100));
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

        check_debt();
    }

    public void loseMoney(int money_lost)
    {
        this.money -= money_lost;

        check_debt();
    }

    public void check_debt()
    {
        if (money < 0)
        {
            borrowed_money += Mathf.Abs(money);

            loan_debt += Mathf.Abs(money);
            money += Mathf.Abs(money);
        }
    }

    public void get_raise()
    {
        pay_raise++;
    }

    public void jobless_day_pass()
    {
        jobless_day--;

        if (jobless_day < 0)
        {
            jobless_day = 0;
        }
    }

    public void jobless_for_x_days(int day)
    {
        jobless_day = day;
    }

    public void add_p_fund(int fund)
    {
        p_fund += fund;
    }

    public void jobless_p_fund_return()
    {
        money += p_fund;
        p_fund = 0;
    }

    public void p_fund_banned_x_days(int banned)
    {
        p_fund_banned += banned;
    }

    public void p_fund_banned_pass()
    {
        p_fund_banned--;
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
        if (partner != null)
        {
            if (partner.partner_job == Athlete)
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

    public void reduceHouseDebt(int house)
    {
        house_debt -= house;
    }

    public void addCarDebt(int car)
    {
        car_debt += car;
    }

    public void reduceCarDebt(int car)
    {
        car_debt -= car;
    }

    public void reduceLoan(int loan)
    {
        loan_debt -= loan;
    }

    public void increase_love_level()
    {
        this.love_level++;
    }


    public void count_insurance_day()
    {
        insurance_day_count++;
    }

    public int child_cost()
    {
        int child_num = love_level - 1;
        if (child_num < 0)
        {
            child_num = 0;
        }
        int cost = 0;

        if (myJob != null)
        {
            cost = child_num * myJob.child_cost;
        }

        if (partner != null)
        {
            // nursery buff 2

            if (partner.partner_job == NurseryTeacher)
            {
                cost = child_num * 100;
            }
        }


        return cost;
    }

    public void no_lover_again()
    {
        this.love_level = 0;
    }

    public void one_step()
    {
        this.step_taken++;
    }

    public void step_reset()
    {
        this.step_taken = 0;
    }
}
