using TMPro;
using UnityEngine;

public class oppo_event_info : MonoBehaviour
{
    public oppo_card new_card;

    public TextMeshProUGUI textmeshPro;

    public statistics player;

    public GameObject button1;
    public GameObject button1_gray;
    public GameObject button2;
    public GameObject button_single;

    public TextMeshProUGUI b1_text;
    public TextMeshProUGUI b1_gray_text;
    public TextMeshProUGUI b2_text;
    public TextMeshProUGUI bsingle_text;

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
        string word = new_card.flavourText;
        textmeshPro.SetText($"{word}");
    }

    public void button_change()
    {
        if (new_card.option_count == 1)
        {
            // oppo 1 button

            string bsingle = new_card.buttonText1;

            button1.SetActive(false);
            button1_gray.SetActive(false);
            button2.SetActive(false);
            button_single.SetActive(true);

            bsingle_text.SetText($"{bsingle}");
        }
        else if (new_card.option_count == 2)
        {
            // oppo 2 buttons

            string b1 = new_card.buttonText1;
            string b2 = new_card.buttonText2;

            button1.SetActive(true);
            button1_gray.SetActive(true);
            button2.SetActive(true);
            button_single.SetActive(false);

            b1_text.SetText($"{b1}");
            b1_gray_text.SetText($"{b1}");
            b2_text.SetText($"{b2}");

            if (new_card.name.StartsWith("work") && new_card.button.energy_loss > player.energy)
            {
                button1.SetActive(false);
            }

            if (new_card.name.StartsWith("raise") && new_card.button.energy_loss > player.energy)
            {
                button1.SetActive(false);
            }

            if (new_card.name.StartsWith("buy") && new_card.button.money_loss > player.money)
            {
                button1.SetActive(false);
            }
        }
    }

    public void set_card(oppo_card _card)
    {
        new_card = _card;
        button_change();
        text_change();
    }
}
