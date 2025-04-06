using TMPro;
using UnityEngine;

public class debt_panel : MonoBehaviour
{
    public statistics player;

    public TextMeshProUGUI house_debt;
    public TextMeshProUGUI car_debt;
    public TextMeshProUGUI loan_debt;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        house_debt.SetText($"{player.house_debt.ToString("N0")}");
        car_debt.SetText($"{player.car_debt.ToString("N0")}");
        loan_debt.SetText($"{player.loan_debt.ToString("N0")}");
    }
}
