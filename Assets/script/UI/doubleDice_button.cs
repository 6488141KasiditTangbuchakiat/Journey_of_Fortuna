using UnityEngine;

public class doubleDice_button : MonoBehaviour
{

    public statistics statistics;
    public GameObject dice_button;

    public tile_event _tile_event;
    public GameObject button_both;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // enable 2 dice option

        if (statistics.hasCar)
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
    }


}
