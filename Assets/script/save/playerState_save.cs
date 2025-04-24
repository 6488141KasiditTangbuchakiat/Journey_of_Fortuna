using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class playerState_save : MonoBehaviour
{
    private SaveManager saveManager;

    public statistics player;
    public playerMovement movement;

    public timer timer;

    public stock stock1;
    public stock stock2;
    public stock stock3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        saveManager = Object.FindFirstObjectByType<SaveManager>();

        // loadPlayerData();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void savePlayerData()
    {
        SaveData data = saveManager.LoadGame();

        if (data == null)
        {
            data = new SaveData();
        }

        // player stats save

        data.save_age = player.age;
        data.save_player_stage = player.player_stage;
        data.save_myJob = player.myJob.name;

        if (player.hasHouse != null)
        {
            data.save_hasHouse = player.hasHouse.name;
        }

        if (player.hasCar != null)
        {
            data.save_hasCar = player.hasCar.name;
        }


        if (player.partner != null)
        {
            data.save_partner = player.partner.name;
        }

        data.save_love_level = player.love_level;

        // money stats + payment
        data.save_money = player.money;

        data.save_reserve_money = player.reserve_money;
        data.save_reserve_money_max = player.reserve_money_max;

        data.save_pay_raise = player.pay_raise;
        data.save_jobless_day = player.jobless_day;

        data.save_p_fund = player.p_fund;
        data.save_p_fund_percentage = player.p_fund_percentage;
        data.save_p_fund_banned = player.p_fund_banned;

        data.save_house_debt = player.house_debt;
        data.save_car_debt = player.car_debt;
        data.save_loan_debt = player.loan_debt;
        data.save_borrowed_money = player.borrowed_money;

        data.save_house_payment_time = player.house_payment_time;
        data.save_car_payment_time = player.car_payment_time;

        // buff debuff
        data.save_reserve_threshold_reached = player.reserve_threshold_reached;

        data.save_energy_cap_buff = player.energy_cap_buff;
        data.save_energy_no_regen_cooldown = player.energy_no_regen_cooldown;
        data.save_cost_reduce_buff = player.cost_reduce_buff;

        data.save_inflation = player.inflation;
        data.save_deflation = player.deflation;
        data.save_ID_cooldown = player.ID_cooldown;

        //passive
        data.save_reserve_passive = player.reserve_passive;

        // energy
        data.save_energy = player.energy;
        data.save_energy_cap = player.energy_cap;

        // stock
        data.save_stock1 = player.stock1;
        data.save_stock2 = player.stock2;
        data.save_stock3 = player.stock3;

        data.save_stock1og = player.stock1og;
        data.save_stock2og = player.stock2og;
        data.save_stock3og = player.stock3og;


        // insurance
        data.save_life_insurance = player.life_insurance;

        if (player.Accident_insurance.Count != 0)
        {
            data.save_Accident_insurance = player.Accident_insurance[0].name;
        }

        if (player.Health_insurance.Count != 0)
        {
            data.save_Health_insurance = player.Health_insurance[0].name;
        }

        data.save_insurance_expire = player.insurance_expire;

        data.save_insurance_day_count = player.insurance_day_count;


        // step taken
        data.save_step_taken = player.step_taken;

        // record

        data.save_life_record = player.life_record;


        // stock price
        data.save_stock1price = stock1.stock_price;
        data.save_stock2price = stock2.stock_price;
        data.save_stock3price = stock3.stock_price;

        // movement
        data.save_movement_counter = movement.age_counter;

        // timer
        data.save_timer = timer.time;


        saveManager.SaveGame(data);


        Debug.Log("player saved");
    }

    public void loadPlayerData()
    {
        SaveData loadedData = saveManager.LoadGame();

        if (loadedData != null)
        {
            player.age = loadedData.save_age;
            player.player_stage = loadedData.save_player_stage;

            string job_location = "/object storage/job/" + loadedData.save_myJob;
            player.myJob = GameObject.Find(job_location).GetComponent<job>();

            if (loadedData.save_hasHouse != null)
            {
                string house_location = "/object storage/houseCar/" + loadedData.save_hasHouse;
                player.hasHouse = GameObject.Find(house_location).GetComponent<house>();
            }

            if (loadedData.save_hasCar != null)
            {
                string car_location = "/object storage/houseCar/" + loadedData.save_hasCar;
                player.hasCar = GameObject.Find(car_location).GetComponent<car>();
            }


            string partner_location = "/object storage/partners/" + loadedData.save_partner;

            if (loadedData.save_partner != null)
            {
                player.partner = GameObject.Find(partner_location).GetComponent<partner>();
            }


            player.love_level = loadedData.save_love_level;

            // money stats + payment
            player.money = loadedData.save_money;

            player.reserve_money = loadedData.save_reserve_money;
            player.reserve_money_max = loadedData.save_reserve_money_max;

            player.pay_raise = loadedData.save_pay_raise;
            player.jobless_day = loadedData.save_jobless_day;

            player.p_fund = loadedData.save_p_fund;
            player.p_fund_percentage = loadedData.save_p_fund_percentage;
            player.p_fund_banned = loadedData.save_p_fund_banned;

            player.house_debt = loadedData.save_house_debt;
            player.car_debt = loadedData.save_car_debt;
            player.loan_debt = loadedData.save_loan_debt;
            player.borrowed_money = loadedData.save_borrowed_money;

            player.house_payment_time = loadedData.save_house_payment_time;
            player.car_payment_time = loadedData.save_car_payment_time;

            // buff debuff
            player.reserve_threshold_reached = loadedData.save_reserve_threshold_reached;

            player.energy_cap_buff = loadedData.save_energy_cap_buff;
            player.energy_no_regen_cooldown = loadedData.save_energy_no_regen_cooldown;
            player.cost_reduce_buff = loadedData.save_cost_reduce_buff;

            player.inflation = loadedData.save_inflation;
            player.deflation = loadedData.save_deflation;
            player.ID_cooldown = loadedData.save_ID_cooldown;

            //passive
            player.reserve_passive = loadedData.save_reserve_passive;

            // energy
            player.energy = loadedData.save_energy;
            player.energy_cap = loadedData.save_energy_cap;

            // stock
            player.stock1 = loadedData.save_stock1;
            player.stock2 = loadedData.save_stock2;
            player.stock3 = loadedData.save_stock3;

            player.stock1og = loadedData.save_stock1og;
            player.stock2og = loadedData.save_stock2og;
            player.stock3og = loadedData.save_stock3og;


            // insurance
            player.life_insurance = loadedData.save_life_insurance;

            string insurance_A_location = "/object storage/insurance/" + loadedData.save_Accident_insurance;
            string insurance_H_location = "/object storage/insurance/" + loadedData.save_Health_insurance;

            insurance insur_a = GameObject.Find(insurance_A_location).GetComponent<insurance>();

            if (insur_a != null)
            {
                player.Accident_insurance.Add(insur_a);
            }

            insurance insur_h = GameObject.Find(insurance_H_location).GetComponent<insurance>();

            if (insur_h != null)
            {
                player.Health_insurance.Add(insur_h);
            }

            player.insurance_expire = loadedData.save_insurance_expire;

            player.insurance_day_count = loadedData.save_insurance_day_count;

            // step taken
            player.step_taken = loadedData.save_step_taken;

            // record
            player.life_record = loadedData.save_life_record;

            // stock price
            stock1.stock_price = loadedData.save_stock1price;
            stock2.stock_price = loadedData.save_stock2price;
            stock3.stock_price = loadedData.save_stock3price;

            // movement
            movement.age_counter = loadedData.save_movement_counter;

            // timer
            timer.time = loadedData.save_timer;


            Debug.Log("player loaded");
        }
    }

    public void savePlayerData_reset_step(int stage)
    {
        player.step_reset();
        player.player_stage = stage;
        savePlayerData();
    }
}
