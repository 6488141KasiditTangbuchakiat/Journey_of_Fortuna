using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class greed_event_info : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI textmeshPro;
    public greed_card new_card;

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
        }
    }

    public void set_card(greed_card _card)
    {
        new_card = _card;
        text_change();
    }
}
