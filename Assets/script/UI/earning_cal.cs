using TMPro;
using UnityEngine;

public class earning_cal : MonoBehaviour
{
    public TextMeshProUGUI income;
    public TextMeshProUGUI expense;
    public TextMeshProUGUI house;
    public TextMeshProUGUI car;
    public TextMeshProUGUI loan;
    public TextMeshProUGUI insur;
    public TextMeshProUGUI child;
    public TextMeshProUGUI actual_income;

    public statistics player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int income_n = player.myJob.salary_on_green_tile;
        int house_n = player.house_debt;
        int car_n = player.car_debt;
        int loan_n = player.loan_debt;
        int insur_n = player.insurance_cost;

        int child_n = player.child_cost();

        int expense_n = house_n + car_n + loan_n + insur_n + child_n;

        int actual_income_n = income_n - expense_n;

        income.SetText($"{income_n}");
        expense.SetText($"{expense_n}");
        house.SetText($"{house_n}");
        car.SetText($"{car_n}");
        loan.SetText($"{loan_n}");
        child.SetText($"{child_n}");
        insur.SetText($"{insur_n}");
        actual_income.SetText($"{actual_income_n}");


    }
}
