using TMPro;
using UnityEngine;

public class doubleDice_button : MonoBehaviour
{

    public statistics statistics;
    public GameObject dice_button;

    public tile_event _tile_event;
    public GameObject button_both;

    public GameObject double_dice_cooldown;
    public TextMeshProUGUI double_dice_text;
    public int cooldown_turn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // enable 2 dice option

        if (statistics.hasCar && cooldown_turn == 0)
        {
            dice_button.SetActive(true);
        }
        else
        {
            dice_button.SetActive(false);
        }

        // block dice button when walking and in event

        if (_tile_event.popup_on)
        {
            button_both.SetActive(false);
        }
        else
        {
            button_both.SetActive(true);
        }

        // 2 dice cool down panel

        if(cooldown_turn > 0)
        {
            double_dice_cooldown.SetActive(true);
            double_dice_text.SetText($"{cooldown_turn} until cooldown");
        }
        else
        {
            double_dice_cooldown.SetActive(false);
        }
    }

    public void cooldown_reduce()
    {
        cooldown_turn--;
    }

    public void add_cooldown(int num)
    {
        cooldown_turn = num;
    }
}
