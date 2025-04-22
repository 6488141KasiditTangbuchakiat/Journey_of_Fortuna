using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class bank : MonoBehaviour
{
    public statistics player;

    public GameObject deposit_button;
    public GameObject withdraw_button;

    public TMP_InputField inputField;

    public TextMeshProUGUI money1;
    public TextMeshProUGUI money2;
    public TextMeshProUGUI money3;

    int money;
    int bank_money;

    int number;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Optional: Force to integer input via code
        inputField.contentType = TMP_InputField.ContentType.IntegerNumber;

        // Listen for changes
        inputField.onValueChanged.AddListener(ValidateInput);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        money = player.money;
        bank_money = player.reserve_money;

        money1.SetText($"à§Ô¹ã¹¡ÃÐà»ëÒ: {money.ToString("N0")}");
        money2.SetText($"à§Ô¹½Ò¡¸¹Ò¤ÒÃ: {bank_money.ToString("N0")}");
        money3.SetText($"{number.ToString("N0")}");

        if((number > money) || (bank_money >= player.reserve_money_max))
        {
            deposit_button.SetActive(false);
        }
        else
        {
            deposit_button.SetActive(true);
        }

        if (number > bank_money)
        {
            withdraw_button.SetActive(false);
        }
        else
        {
            withdraw_button.SetActive(true);
        }

    }

    public void addMoney(int added_money)
    {
        number += added_money;

        if(money > bank_money)
        {
            if(number > money)
            {
                number = money;
            }
        }
        else
        {
            if (number > bank_money)
            {
                number = bank_money;
            }
        }

        change_input_to_num();
    }

    public void maxMoney()
    {
        number = player.reserve_money_max;

        if(number > player.money)
        {
            number = player.money;
        }

        change_input_to_num();
    }

    public void minMoney()
    {
        number = 0;

        change_input_to_num();
    }

    public void removeMoney(int added_money)
    {
        number -= added_money;

        if(number < 0 )
        {
            number = 0;
        }

        change_input_to_num();
    }

    public void deposit()
    {

        player.money -= number;
        player.reserve_money += number;

        if(player.reserve_money > player.reserve_money_max)
        {
            int overflow = player.reserve_money - player.reserve_money_max;

            player.reserve_money -= overflow;
            player.money += overflow;
        }
    }

    public void withdraw()
    {

        player.reserve_money -= number;
        player.money += number;
    }

    void ValidateInput(string value)
    {
        // Extra layer: Remove non-numeric characters if needed
        string result = "";
        foreach (char c in value)
        {
            if (char.IsDigit(c))
                result += c;
        }

        if (result != value)
        {
            inputField.text = result; // Sanitize input
        }

        if (inputField.text == "")
        {
            inputField.text = "0";
        }
        number = int.Parse(inputField.text);
    }

    void change_input_to_num()
    {
        inputField.text = number.ToString();
    }
}
