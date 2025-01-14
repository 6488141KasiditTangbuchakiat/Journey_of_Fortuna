using UnityEngine;

public class greed_event : MonoBehaviour
{
    public GameObject event_panel;
    public greed_event_info event_text;
    public statistics statistics;

    public deck_mechanics normal_deck;
    public deck_mechanics partner_deck;
    public deck_mechanics child_deck;

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
        event_text.set_card((greed_card)_card);
    }
}
