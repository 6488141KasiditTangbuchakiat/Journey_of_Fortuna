using TMPro;
using UnityEngine;

public class stock_bar : MonoBehaviour
{
    public stock stock1;
    public stock stock2;
    public stock stock3;

    public TextMeshProUGUI com1;
    public TextMeshProUGUI com2;
    public TextMeshProUGUI com3;

    public TextMeshProUGUI com1p;
    public TextMeshProUGUI com2p;
    public TextMeshProUGUI com3p;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        com1.SetText($"{stock1.company_name}:");
        com2.SetText($"{stock2.company_name}:");
        com3.SetText($"{stock3.company_name}:");

        com1p.SetText($"{stock1.stock_price} baht");
        com2p.SetText($"{stock2.stock_price} baht");
        com3p.SetText($"{stock3.stock_price} baht");
    }
}
