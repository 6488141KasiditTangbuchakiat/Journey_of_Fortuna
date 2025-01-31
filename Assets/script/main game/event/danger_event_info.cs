using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static insurance;
using static partner.Job_type;

public class danger_event_info : MonoBehaviour
{
    public TextMeshProUGUI textmeshPro;
    public TextMeshProUGUI textmeshPro2;

    public danger_card new_card;

    public statistics player;
    public insurance insurance_used;

    public GameObject payFull;
    public GameObject paySome;
    public GameObject death;

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
                // lead to something else

                textmeshPro.SetText($"{word}");
                textmeshPro2.SetText($"เหตุการ์ณไม่คาดฝันกำลังเกิดขึ้น โปรดทำใจให้ดีๆ");

            }
            else if (new_card.type == type.None)
            {
                textmeshPro2.SetText($"เป็เหตุการณ์ที่ไม่คาดฝันจริงๆ");

                if (new_card.name == "dl1" && player.love_level == 1)
                {
                    //divorce
                    // moneyLost = player.money / 2;
                    player.partner = null;
                    player.no_lover_again();
                }
                else if (new_card.name == "d3")
                {
                    // lawsuit
                    moneyLost = player.money / 2;

                    if (player.partner != null)
                    {
                        if (player.partner.partner_job == Lawyer)
                        {
                            textmeshPro2.SetText($"เพราะแฟนคุณเป็นทนายความ เลยพ้นคำฟ้องร้องนี้");
                            moneyLost = 0;
                        }
                    }
                }
                else if (new_card.name == "d4")
                {
                    //downsize

                    player.jobless_for_x_days(2);
                    player.jobless_p_fund_return();
                }

                if (moneyLost > 0)
                {
                    textmeshPro.SetText($"{word}\nคุณเสียเงิน {moneyLost} บาท");
                }
                else
                {
                    textmeshPro.SetText($"{word}");
                }

                player.ExpenseMoney(moneyLost);
            }
            else if (new_card.type == type.Life)
            {
                // life

                textmeshPro.SetText($"{word}\nคุณเสียเงิน {moneyLost} บาท");
                textmeshPro2.SetText($"...");
                player.step_reset();

                if (player.life_insurance == false)
                {
                    moneyLost = calculator.x_in_y_percent(player.money, 50);
                    player.ExpenseMoney(moneyLost);

                }

                if (moneyLost == 0)
                {
                    textmeshPro.SetText($"{word}");
                }


            }
            else
            {
                // health, accident

                textmeshPro.SetText($"{word}\nคุณเสียเงิน  {moneyLost}  บาท");

                if (moneyLost == 0)
                {
                    // free

                    textmeshPro.SetText($"{word}");
                    textmeshPro2.SetText($"คุณไม่ต้องจ่ายเองสักแดงเดียว");
                }
                else if (suitable_insurance)
                {
                    // has insurance

                    insurance.type type = insurance_used.InType;
                    insurance.tier tier = insurance_used.InTier;
                    double reduction = insurance_used.reduction;

                    int newPayment = (int)(moneyLost * ((100 - reduction) / 100));

                    if (player.partner != null)
                    {
                        // doctor partner buff

                        if (player.partner.partner_job == Doctor)
                        {
                            newPayment = (int)(moneyLost - (moneyLost * 50 / 100));
                        }
                    }

                    if (newPayment > 0)
                    {
                        // insurance with discount

                        textmeshPro2.SetText($"Because you have {type} insurance with {tier} tier, you get {reduction}% discount, paying {newPayment} instead.");

                        player.ExpenseMoney(newPayment);
                    }
                    else
                    {
                        // insurance makes it free

                        //textmeshPro2.SetText($"Because you have {type} insurance with {tier} tier, you don't have to pay.");
                        textmeshPro2.SetText($"เนื่องจากคุณทำประกันวงเงินสูงที่ครอบคลุมเงื่อนไขของคุณ ทำให้คุณไม่ต้องจ่ายเองเลย");
                    }

                }
                else
                {
                    // no insurance

                    textmeshPro2.SetText($"คุณไม่ได้ทำประกันที่เกี่ยวข้องไว้ คุณต้องจ่ายเองเต็มๆ");

                    player.ExpenseMoney(moneyLost);
                }
            }


        }
    }

    void button_change()
    {
        suitable_insurance = false;

        payFull.SetActive(false);
        paySome.SetActive(false);
        death.SetActive(false);

        if (new_card.type == type.Accident)
        {
            // has accident insurance

            if (player.Accident_insurance.Count > 0)
            {
                suitable_insurance = true;
                insurance_used = player.Accident_insurance[0];
            }

        }
        else if (new_card.type == type.Health)
        {
            // has health insurance

            if (player.Health_insurance.Count > 0)
            {
                suitable_insurance = true;
                insurance_used = player.Health_insurance[0];
            }

        }
        else if (new_card.type == type.Life)
        {
            payFull.SetActive(false);
            paySome.SetActive(false);
            death.SetActive(true);
        }

        if (suitable_insurance)
        {
            // claim insurance button enable

            paySome.SetActive(true);
            payFull.SetActive(false);
        }
        else
        {
            // doesn't have insurance button

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
