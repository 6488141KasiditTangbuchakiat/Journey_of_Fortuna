using TMPro;
using UnityEngine;

public class oppo_p2_event_info : MonoBehaviour
{
    public oppo_p2_card new_card;

    public oppo_card input_card;

    public TextMeshProUGUI textmeshPro;
    public TextMeshProUGUI textMoney;
    public TextMeshProUGUI textEnergy;

    public statistics player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void text_change()
    {
        string text_here = new_card.text;
        int money_gain = new_card.money_gain;
        int money_loss = new_card.money_loss;
        int energy_gain = new_card.energy_gain;
        int energy_loss = new_card.energy_loss;

        textmeshPro.SetText($"{text_here}");
        textMoney.SetText("");
        textEnergy.SetText("");

        if (new_card.money_gain > 0)
        {
            player.addMoney(new_card.money_gain);
            textMoney.SetText($"\nคุณได้รับเงิน {money_gain} บาท");
        }

        if (new_card.money_loss > 0)
        {
            player.loseMoney(new_card.money_loss);
            textMoney.SetText($"\nคุณเสียเงิน {money_loss} บาท");
        }
        if (new_card.energy_gain > 0)
        {
            player.addEnergy_disregard_house(new_card.energy_gain);
            textEnergy.SetText($"\nคุณได้รับพลังงาน {energy_gain} หน่วย");
        }
        if (new_card.energy_loss > 0)
        {
            player.loseEnergy(new_card.energy_loss);
            textEnergy.SetText($"\nคุณเสียพลังงาน {energy_loss} หน่วย");
        }

    }

    public void set_card(oppo_p2_card _card)
    {
        text_change();
    }

    public void get_input_card(oppo_card card)
    {
        input_card = card;
    }

    public void button_call()
    {
        new_card = input_card.button;

        set_card(new_card);
    }

    public void button_call2()
    {
        new_card = input_card.button2;

        set_card(new_card);
    }
}
