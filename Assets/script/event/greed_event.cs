using UnityEngine;

public class greed_event : MonoBehaviour
{
    public GameObject event_panel;
    public greed_event_info event_text;
    public deck_mechanics deck;
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
        _card = deck.drawCard();
        event_text.set_card((greed_card)_card);
    }
}
