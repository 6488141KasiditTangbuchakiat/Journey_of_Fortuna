using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class playerState_save : MonoBehaviour
{
    private SaveManager saveManager;

    public statistics player;

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

        data.save_hasHouse = player.hasHouse;
        data.save_hasCar = player.hasCar;

        if (player.partner != null)
        {
            data.save_partner = player.partner.name;
        }

        data.save_love_level = player.love_level;

        // money stats + payment
        data.save_money = player.money;

        data.save_jobless_day = player.jobless_day;

        data.save_p_fund = player.p_fund;
        data.save_p_fund_percentage = player.p_fund_percentage;
        data.save_p_fund_banned = player.p_fund_banned;

        data.save_house_debt = player.house_debt;
        data.save_car_debt = player.car_debt;
        data.save_loan_debt = player.loan_debt;
        data.save_borrowed_money = player.borrowed_money;

        // energy
        data.save_energy = player.energy;
        data.save_energy_cap = player.energy_cap;

        // stock
        data.save_stock1 = player.stock1;
        data.save_stock2 = player.stock2;
        data.save_stock3 = player.stock3;


        // insurance
        data.save_life_insurance = player.life_insurance;

        data.save_Accident_insurance = player.Accident_insurance;
        data.save_Health_insurance = player.Health_insurance;


        // step taken
        data.save_step_taken = player.step_taken;


        // stock price
        data.save_stock1price = stock1.stock_price;
        data.save_stock2price = stock2.stock_price;
        data.save_stock3price = stock3.stock_price;

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

            player.hasHouse = loadedData.save_hasHouse;
            player.hasCar = loadedData.save_hasCar;

            string partner_location = "/object storage/partners/" + loadedData.save_partner;

            if (loadedData.save_partner != null)
            {
                player.partner = GameObject.Find(partner_location).GetComponent<partner>();
            }


            player.love_level = loadedData.save_love_level;

            // money stats + payment
            player.money = loadedData.save_money;

            player.jobless_day = loadedData.save_jobless_day;

            player.p_fund = loadedData.save_p_fund;
            player.p_fund_percentage = loadedData.save_p_fund_percentage;
            player.p_fund_banned = loadedData.save_p_fund_banned;

            player.house_debt = loadedData.save_house_debt;
            player.car_debt = loadedData.save_car_debt;
            player.loan_debt = loadedData.save_loan_debt;
            player.borrowed_money = loadedData.save_borrowed_money;

            // energy
            player.energy = loadedData.save_energy;
            player.energy_cap = loadedData.save_energy_cap;

            // stock
            player.stock1 = loadedData.save_stock1;
            player.stock2 = loadedData.save_stock2;
            player.stock3 = loadedData.save_stock3;


            // insurance
            player.life_insurance = loadedData.save_life_insurance;

            player.Accident_insurance = loadedData.save_Accident_insurance;
            player.Health_insurance = loadedData.save_Health_insurance;

            // step taken
            player.step_taken = loadedData.save_step_taken;

            // stock price
            stock1.stock_price = loadedData.save_stock1price;
            stock2.stock_price = loadedData.save_stock2price;
            stock3.stock_price = loadedData.save_stock3price;

            Debug.Log("player loaded");
        }
    }

    public void savePlayerData_reset_step()
    {
        player.step_reset();
        savePlayerData();
    }
}
