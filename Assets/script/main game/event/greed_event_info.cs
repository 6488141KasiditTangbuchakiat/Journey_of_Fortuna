using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static partner.Job_type;

public class greed_event_info : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI textmeshPro;
    public TextMeshProUGUI button_text;
    public TextMeshProUGUI button1_text;
    public TextMeshProUGUI button2_text;



    public greed_card new_card;

    public statistics player;

    public GameObject button_single;
    public GameObject button_1;
    public GameObject button_2;

    int num = 0;


    void Start()
    {

    }

    // Update is called once per frame
    void text_change()
    {

        if (new_card != null)
        {
            string word = new_card.flavourText;
            num = new_card.moneyLost;

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

            if (new_card.option_count == 1)
            {
                button_single.SetActive(true);
                button_1.SetActive(false);
                button_2.SetActive(false);

                textmeshPro.SetText($"{word}\n คุณเสียเงิน {num} บาท");
                button_text.SetText($"{new_card.reactionText}");
            }
            else if (new_card.option_count == 2)
            {
                button_single.SetActive(false);
                button_1.SetActive(true);

                if (new_card.energyLost > player.energy)
                {
                    button_2.SetActive(false);
                }
                else
                {
                    button_2.SetActive(true);
                }


                textmeshPro.SetText($"{word}\n คุณเสียเงิน {num} บาท\n use {new_card.energyLost} energy to pay {new_card.moneyLost_alt} บาท");
                button1_text.SetText($"{new_card.reactionText}");
                button2_text.SetText($"{new_card.reactionText_alt}");
            }



            //player.ExpenseMoney(num);
        }
    }

    public void set_card(greed_card _card)
    {
        new_card = _card;
        text_change();
    }

    public void player_pays()
    {
        player.ExpenseMoney(num);
    }

    public void player_pays_with_energy()
    {
        player.ExpenseMoney(new_card.moneyLost_alt);
        player.loseEnergy(new_card.energyLost);
    }
}
