using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class news_event_info : MonoBehaviour
{


    TextMeshProUGUI textmeshPro;

    public news_card new_card;


    void Start()
    {
        textmeshPro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void text_change()
    {

        if(new_card != null)
        {
            string word = new_card.stock_name;
            int num = new_card.stock_price;
            textmeshPro.SetText($"Today NEWS : {word}, Stock price change to:\n{num} per stock");
        }
    }

    public void set_card(news_card _card)
    {
        new_card = _card;
        text_change();
    }
}
