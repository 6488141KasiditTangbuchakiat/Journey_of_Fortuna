using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class house_panel : MonoBehaviour
{
    public statistics player;

    public TextMeshProUGUI h_all;
    public TextMeshProUGUI h_down;
    public TextMeshProUGUI h_own;

    public TextMeshProUGUI c_all;
    public TextMeshProUGUI c_down;
    public TextMeshProUGUI c_own;

    public house house1;
    public car car1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(house1 != null)
        {
            h_all.SetText($"{(house1.down_cost + house1.mortgage).ToString("N0")}");
            h_down.SetText($"{house1.down_cost.ToString("N0")}");

            if (player.hasHouse != null)
            {
                h_own.SetText("ซื้อแล้ว");
            }
            else
            {
                h_own.SetText("");
            }
        }

        if(car1 != null)
        {
            c_all.SetText($"{(car1.down_cost + car1.mortgage).ToString("N0")}");
            c_down.SetText($"{car1.down_cost.ToString("N0")}");

            if (player.hasCar != null)
            {
                c_own.SetText("ซื้อแล้ว");
            }
            else
            {
                c_own.SetText("");
            }
        }
    }
}
