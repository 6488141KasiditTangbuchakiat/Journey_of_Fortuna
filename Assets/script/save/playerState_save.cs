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
    public string scene_name;

    public stock stock1;
    public stock stock2;
    public stock stock3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        saveManager = Object.FindFirstObjectByType<SaveManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void savePlayerData()
    {
        SaveData data = new SaveData
        {

            // player stats save

            save_age = player.age,
            save_player_stage = player.player_stage,
            save_myJob = player.myJob,

            save_hasHouse = player.hasHouse,
            save_hasCar = player.hasCar,

            save_partner = player.partner,
            save_love_level = player.love_level,

            // money stats + payment
            save_money = player.money,

            save_jobless_day = player.jobless_day,

            save_p_fund = player.p_fund,
            save_p_fund_percentage = player.p_fund_percentage,

            save_house_debt = player.house_debt,
            save_car_debt = player.car_debt,
            save_loan_debt = player.loan_debt,
            save_borrowed_money = player.borrowed_money,

            // energy
            save_energy = player.energy,
            save_energy_cap = player.energy_cap,

            // stock
            save_stock1 = player.stock1,
            save_stock2 = player.stock2,
            save_stock3 = player.stock3,


            // insurance
            save_life_insurance = player.life_insurance,

            save_Accident_insurance = player.Accident_insurance,
            save_Health_insurance = player.Health_insurance,


            // movement
            save_currentTile = movement.currentTile,

            // stock price
            save_stock1price = stock1.stock_price,
            save_stock2price = stock2.stock_price,
            save_stock3price = stock3.stock_price,

        };

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
            player.myJob = loadedData.save_myJob;

            player.hasHouse = loadedData.save_hasHouse;
            player.hasCar = loadedData.save_hasCar;

            player.partner = loadedData.save_partner;
            player.love_level = loadedData.save_love_level;

            // money stats + payment
            player.money = loadedData.save_money;

            player.jobless_day = loadedData.save_jobless_day;

            player.p_fund = loadedData.save_p_fund;
            player.p_fund_percentage = loadedData.save_p_fund_percentage;

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



            // movement
            movement.currentTile = loadedData.save_currentTile;

            // stock price
            stock1.stock_price = loadedData.save_stock1price;;
            stock2.stock_price = loadedData.save_stock2price;
            stock3.stock_price = loadedData.save_stock3price;

            Debug.Log("player loaded");
        }
    }
}
