﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static partner.Job_type;

public class greed_event_info : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI textmeshPro;
    public TextMeshProUGUI button_text;
    public greed_card new_card;

    public statistics player;

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

            if (player.partner != null && new_card.name.StartsWith("c"))
            {
                // partner nursery buff

                if (player.partner.partner_job == NurseryTeacher)
                {
                    num = 0;
                }
            }



            if (new_card.name.StartsWith("house"))
            {
                // house <- engineer

                if (player.partner != null)
                {
                    if (player.partner.partner_job == Engineer)
                    {
                        num = num - calculator.x_in_y_percent(num, 30);
                    }
                }
            }
            else if (new_card.name.StartsWith("car"))
            {
                // car <- technician

                if (player.partner != null)
                {
                    if (player.partner.partner_job == Technician)
                    {
                        num = num - calculator.x_in_y_percent(num, 30);
                    }
                }
            }

            textmeshPro.SetText($"{word}\n คุณเสียเงิน {num} บาท");
            button_text.SetText($"{new_card.reactionText}");
            



            player.ExpenseMoney(num);
        }
    }

    public void set_card(greed_card _card)
    {
        new_card = _card;
        text_change();
    }
}
