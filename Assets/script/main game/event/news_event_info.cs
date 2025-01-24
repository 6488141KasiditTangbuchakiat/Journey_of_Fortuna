using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class news_event_info : MonoBehaviour
{

    public TextMeshProUGUI company;
    public TextMeshProUGUI price_change;

    public news_card new_card;

    public stock stock1;
    public stock stock2;
    public stock stock3;

    void Start()
    {

    }

    // Update is called once per frame
    void text_change()
    {

        if (new_card != null)
        {

            int id = new_card.stock_id;
            int num = new_card.stock_price;

            if (id == 1)
            {
                company.SetText($"NEWS: {stock1.company_name}'s stock price changed.");
                stock1.change_stock_price(num);

            }
            else if (id == 2)
            {
                company.SetText($"NEWS: {stock2.company_name}'s stock price changed.");
                stock2.change_stock_price(num);
            }
            else if (id == 3)
            {
                company.SetText($"NEWS: {stock3.company_name}'s stock price changed.");
                stock3.change_stock_price(num);
            }


            price_change.SetText($"Stock price change to: {num} per stock");

        }
    }

    public void set_card(news_card _card)
    {
        new_card = _card;
        text_change();
    }
}
