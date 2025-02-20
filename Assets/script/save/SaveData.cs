using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{

    public int player_gender;
    public string player_name;

    // player stats save

    public int save_age;
    public int save_player_stage;
    public string save_myJob;

    public bool save_hasHouse;
    public bool save_hasCar;

    public string save_partner;
    public int save_love_level;

    // money stats + payment
    public int save_money;

    public int save_jobless_day;

    public int save_p_fund;
    public int save_p_fund_percentage;
    public int save_p_fund_banned;

    public int save_house_debt;
    public int save_car_debt;
    public int save_loan_debt;
    public int save_borrowed_money;

    // energy
    public int save_energy;
    public int save_energy_cap;

    // stock
    public int save_stock1;
    public int save_stock2;
    public int save_stock3;


    // insurance
    public bool save_life_insurance;

    public List<insurance> save_Accident_insurance;
    public List<insurance> save_Health_insurance;

    public int save_insurance_day_count;


    // step taken
    public int save_step_taken;


    // stock price
    public int save_stock1price;
    public int save_stock2price;
    public int save_stock3price;






    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
