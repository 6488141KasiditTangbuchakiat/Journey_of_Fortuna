using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{

    public int player_gender;
    public string player_name;
    public int player_difficulty;

    // player stats save

    public int save_age;
    public int save_player_stage;
    public string save_myJob;

    public string save_hasHouse;
    public string save_hasCar;

    public string save_partner;
    public int save_love_level;

    // money stats + payment
    public int save_money;

    public int save_reserve_money;
    public int save_reserve_money_max;

    public int save_pay_raise;
    public int save_jobless_day;

    public int save_p_fund;
    public int save_p_fund_percentage;
    public int save_p_fund_banned;

    public int save_house_debt;
    public int save_car_debt;
    public int save_loan_debt;
    public int save_borrowed_money;

    public int save_house_payment_time;
    public int save_car_payment_time;

    // buff debuff
    public int save_reserve_threshold_reached;

    public int save_energy_cap_buff;
    public int save_energy_no_regen_cooldown;
    public int save_cost_reduce_buff;

    public int save_inflation;
    public int save_deflation;
    public int save_ID_cooldown;

    // passive
    public int save_reserve_passive;


    // energy
    public int save_energy;
    public int save_energy_cap;

    // stock
    public int save_stock1;
    public int save_stock2;
    public int save_stock3;

    public int save_stock1og;
    public int save_stock2og;
    public int save_stock3og;


    // insurance
    public bool save_life_insurance;

    public string save_Accident_insurance;
    public string save_Health_insurance;

    public int save_insurance_expire;
    public int save_insurance_expire_a;
    public int save_insurance_expire_h;

    public int save_insurance_day_count;


    // step taken
    public int save_step_taken;

    // record
    public List<string> save_life_record = new List<string>();

    // stock price
    public int save_stock1price;
    public int save_stock2price;
    public int save_stock3price;

    // movement

    public int save_movement_counter;

    // timer

    public float save_timer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
