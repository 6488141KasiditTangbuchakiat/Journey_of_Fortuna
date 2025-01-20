using TMPro;
using UnityEngine;

public class oppo_p2_event_info : MonoBehaviour
{
    public oppo_p2_card new_card;

    public oppo_card input_card;

    public TextMeshProUGUI textmeshPro;

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

        textmeshPro.SetText($"{text_here}");

        if(new_card.name == "o1-1")
        {
            player.addMoney(100);
            player.loseEnergy(5);
        }

        if(new_card.name == "o3-1")
        {
            player.ExpenseMoney(100);
            player.addEnergy(5);
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
