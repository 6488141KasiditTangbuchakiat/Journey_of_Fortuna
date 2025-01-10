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
            int num = new_card.moneyLost;
            textmeshPro.SetText($"{word}\n You lose {num} Baht.");

            if (suitable_insurance)
            {
                insurance.type type = insurance_used.InType;
                insurance.tier tier = insurance_used.InTier;
                double reduction = insurance_used.reduction;

                textmeshPro2.SetText($"Because you have {type} insurance with {tier} tier, you get {reduction}% discount.");
            }
            else
            {
                textmeshPro2.SetText($"You don't have the suitable insurance. You have to pay in full.");
            }
        }
    }

    void button_change()
    {
        suitable_insurance = false;

        if (player_insurance.insurance.Length > 0)
        {
            foreach (insurance i in player_insurance.insurance)
            {
                if (i.InType == new_card.type)
                {
                    suitable_insurance = true;
                    insurance_used = i;
                }
            }
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
