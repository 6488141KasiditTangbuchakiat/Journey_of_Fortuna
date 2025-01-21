using TMPro;
using UnityEngine;

public class debt_panel : MonoBehaviour
{
    public statistics player;

    public TextMeshProUGUI house_debt;
    public TextMeshProUGUI car_debt;
    public TextMeshProUGUI loan_debt;

    public int paid_money = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void add_money(int amount)
    {
        player.money += amount;
    }

    void reduce_money(int amount)
    {
        player.money -= amount;
    }
}
