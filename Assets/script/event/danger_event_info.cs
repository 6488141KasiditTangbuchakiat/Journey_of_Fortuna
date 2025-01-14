using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static insurance;

public class danger_event_info : MonoBehaviour
{
    public TextMeshProUGUI textmeshPro;
    public TextMeshProUGUI textmeshPro2;

    public danger_card new_card;

    public statistics player_insurance;
    public insurance insurance_used;

    public GameObject payFull;
    public GameObject paySome;

    bool suitable_insurance = false;

    void Start()
    {

    }

    // Update is called once per frame
    void text_change()
    {

        if (new_card != null)
        {
            string word = new_card.flavourText;
            int moneyLost = new_card.moneyLost;

            if (new_card.type == type.Prelude)
            {
                textmeshPro.SetText($"{word}");
                textmeshPro2.SetText($"Something is about to happen. Roll your dice.");

            }
            else if (new_card.type == type.None)
            {
                if (player_insurance.love_level == 1)
                {
                    moneyLost = player_insurance.money / 2;
                }
                else if (new_card.name == "d3")
                {
                    moneyLost = player_insurance.money / 2;
                }

                textmeshPro.SetText($"{word}\nYou lose {moneyLost} Baht.");
                textmeshPro2.SetText($"What happened, happened.");
            }
            else
            {
                textmeshPro.SetText($"{word}\nYou lose {moneyLost} Baht.");

                if (moneyLost == 0)
                {
                    textmeshPro2.SetText($"You don't have to pay for anything here.");
                }
                else if (suitable_insurance)
                {
                    insurance.type type = insurance_used.InType;
                    insurance.tier tier = insurance_used.InTier;
                    double reduction = insurance_used.reduction;

                    int newPayment = (int)(moneyLost * ((100 - reduction) / 100));

                    if (newPayment > 0)
                    {
                        textmeshPro2.SetText($"Because you have {type} insurance with {tier} tier, you get {reduction}% discount, paying {newPayment} instead.");
                    }
                    else
                    {
                        textmeshPro2.SetText($"Because you have {type} insurance with {tier} tier, you don't have to pay.");
                    }

                }
                else
                {
                    textmeshPro2.SetText($"You don't have the suitable insurance. You have to pay in full.");
                }
            }


        }
    }

    void button_change()
    {
        suitable_insurance = false;

        if (new_card.type == type.Accident)
        {
            if (player_insurance.Accident_insurance.Count > 0)
            {
                suitable_insurance = true;
                insurance_used = player_insurance.Accident_insurance[0];
            }

        }
        else if (new_card.type == type.Health)
        {
            if (player_insurance.Health_insurance.Count > 0)
            {
                suitable_insurance = true;
                insurance_used = player_insurance.Health_insurance[0];
            }

        }
        else if (new_card.type == type.Life)
        {

        }

        if (suitable_insurance)
        {
            paySome.SetActive(true);
            payFull.SetActive(false);
        }
        else
        {
            payFull.SetActive(true);
            paySome.SetActive(false);
        }

    }

    public void set_card(danger_card _card)
    {
        new_card = _card;
        button_change();
        text_change();
    }
}
