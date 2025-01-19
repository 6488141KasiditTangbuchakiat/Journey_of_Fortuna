using UnityEngine;
using TMPro;

public class house_panel : MonoBehaviour
{
    public TextMeshProUGUI h_down;
    public TextMeshProUGUI h_mort;

    public TextMeshProUGUI c_down;
    public TextMeshProUGUI c_mort;

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
            h_down.SetText($"{house1.down_cost}");
            h_mort.SetText($"{house1.mortgage}");
        }

        if(car1 != null)
        {
            c_down.SetText($"{car1.down_cost}");
            c_mort.SetText($"{car1.mortgage}");
        }
    }
}
