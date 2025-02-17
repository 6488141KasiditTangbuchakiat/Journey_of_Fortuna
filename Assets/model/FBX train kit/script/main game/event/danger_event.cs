using UnityEngine;

public class danger_event : MonoBehaviour
{
    public GameObject event_panel;
    public danger_event_info event_text;

    public deck_mechanics deck;
    public deck_mechanics partner_deck;
    public card _card;

    public statistics statistics;

    public tile_event popup_fixer;

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

        if (statistics.love_level == 0)
        {
            _card = deck.drawCard();
        }
        else if (statistics.love_level == 1)
        {
            int num = Random.Range(0, 100);

            if (num >= 0 && num < 75)
            {
                _card = deck.drawCard();
            }
            else
            {
                _card = partner_deck.drawCard();
            }
        }
        else
        {
            _card = deck.drawCard();
        }



        event_text.set_card((danger_card)_card);
    }

    public void event_with_specific_deck()
    {
        string deck_location = "/object storage/card/danger";

        if (_card.name == "d1")
        {
            popup_fixer.popup_on = true;
            deck_mechanics newDeck;

            newDeck = GameObject.Find($"{deck_location}/danger follow up accident").GetComponent<deck_mechanics>();

            event_panel.SetActive(true);
            _card = newDeck.drawCard();

            event_text.set_card((danger_card)_card);
        }
        else if (_card.name == "p1")
        {
            popup_fixer.popup_on = true;
            deck_mechanics newDeck;

            newDeck = GameObject.Find($"{deck_location}/danger prelude 1").GetComponent<deck_mechanics>();

            event_panel.SetActive(true);
            _card = newDeck.drawCard();

            event_text.set_card((danger_card)_card);
        }
        else if (_card.name == "p2")
        {
            popup_fixer.popup_on = true;
            deck_mechanics newDeck;

            newDeck = GameObject.Find($"{deck_location}/danger prelude 2").GetComponent<deck_mechanics>();

            event_panel.SetActive(true);
            _card = newDeck.drawCard();

            event_text.set_card((danger_card)_card);

        }

    }

    public void event_with_specific_card(card _card)
    {
        event_text.set_card((danger_card)_card);
    }
}
