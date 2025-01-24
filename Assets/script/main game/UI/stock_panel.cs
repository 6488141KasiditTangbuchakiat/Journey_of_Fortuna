using TMPro;
using UnityEngine;

public class stock_panel : MonoBehaviour
{
    public statistics player;

    public TextMeshProUGUI stock1_text;
    public TextMeshProUGUI stock2_text;
    public TextMeshProUGUI stock3_text;

    public TextMeshProUGUI price1_text;
    public TextMeshProUGUI price2_text;
    public TextMeshProUGUI price3_text;

    public TextMeshProUGUI own1_text;
    public TextMeshProUGUI own2_text;
    public TextMeshProUGUI own3_text;


    public stock stock1;
    public stock stock2;
    public stock stock3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        stock1_text.SetText($"Stock 1: {stock1.company_name}");
        stock2_text.SetText($"Stock 2: {stock2.company_name}");
        stock3_text.SetText($"Stock 3: {stock3.company_name}");

        price1_text.SetText($"{stock1.stock_price}");
        price2_text.SetText($"{stock2.stock_price}");
        price3_text.SetText($"{stock3.stock_price}");

        own1_text.SetText($"{player.stock1}");
        own2_text.SetText($"{player.stock2}");
        own3_text.SetText($"{player.stock3}");

    }
}
