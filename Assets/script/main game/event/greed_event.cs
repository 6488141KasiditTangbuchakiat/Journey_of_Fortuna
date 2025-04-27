using Unity.VisualScripting;
using UnityEngine;

public class greed_event : MonoBehaviour
{
    public GameObject event_panel;
    public greed_event_info event_text;
    public statistics statistics;

    public deck_mechanics normal_deck;
    public deck_mechanics partner_deck;
    public deck_mechanics child_deck;
    public deck_mechanics house_deck;
    public deck_mechanics car_deck;

    public card _card;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void eventPopUp()
    {
        event_panel.SetActive(true);

        int num = Random.Range(0, 100);

        if(num >= 0 && num < 25 && statistics.hasHouse != null) {
            _card = house_deck.drawCard();

        }else if (num >= 25 && num < 50 && statistics.hasCar != null)
        {
            _card = car_deck.drawCard();
        }
        else
        {
            randomWithParter();
        }

        event_text.set_card((greed_card)_card);
    }

    public void eventPopUp_debug_mode()
    {
        event_panel.SetActive(true);

        GameObject go = new GameObject("debug_greed_card");

        go.AddComponent<greed_card>();

        greed_card new_card = go.GetComponent<greed_card>();

        new_card.flavourText = "พ่อแม่ป่วย จำเป็นต้องใช้เงินในกระเป๋าทั้งหมด";
        new_card.moneyLost = statistics.money - 500;

        if(new_card.moneyLost < 0)
        {
            new_card.moneyLost = statistics.money;
        }

        new_card.reactionText = "จ่าย";
        new_card.option_count = 1;

        event_text.set_card((greed_card)new_card);
    }

    public void randomWithParter()
    {
        if (statistics.love_level == 0)
        {
            _card = normal_deck.drawCard();
        }
        else if (statistics.love_level == 1)
        {
            int num = Random.Range(0, 100);

            if (num >= 0 && num < 75)
            {
                _card = normal_deck.drawCard();
            }
            else
            {
                _card = partner_deck.drawCard();
            }
        }
        else
        {
            int num = Random.Range(0, 100);

            if (num >= 0 && num < 50)
            {
                _card = normal_deck.drawCard();
            }
            else if (num >= 50 && num < 75)
            {
                _card = partner_deck.drawCard();
            }
            else
            {
                _card = child_deck.drawCard();
            }

        }
    }
}
