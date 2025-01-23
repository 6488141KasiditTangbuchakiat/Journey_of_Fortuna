using TMPro;
using UnityEngine;
using static partner.Job_type;

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
    public playerMovement movement;

    int actual_income_n = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {


    }

    public void event_on_popup()
    {
        setText();

        player.addMoney(actual_income_n);

        if (player.partner != null)
        {
            // partner chef buff

            if (player.partner.partner_job == Chef)
            {
                player.addEnergy_disregard_house(5);
            }
        }
    }

    public void setText()
    {
        int income_n = player.myJob.salary_on_green_tile * movement.pass_earn_num_and_reset();

        if(player.jobless_day > 0)
        {
            income_n = 0;
            player.jobless_day_pass();
        }

        if(player.p_fund_percentage > 0)
        {
            int pfund_money = income_n * player.p_fund_percentage / 100;

            income_n = income_n - pfund_money;
            player.add_p_fund(pfund_money);

        }

        /*
        int house_n = player.house_debt;
        int car_n = player.car_debt;
        */

        int house_n = 0;
        int car_n = 0;


        int loan_n = player.loan_debt;
        // int insur_n = player.inLife_cost + player.inAccident_cost + player.inHealth_cost;
        int insur_n = 0;

        int child_n = player.child_cost();

        int expense_n = house_n + car_n + loan_n + insur_n + child_n;

        if (player.partner != null)
        {
            // partner businessperson buff

            if (player.partner.partner_job == BusinessPerson)
            {
                income_n = (int)(income_n + Mathf.Abs(income_n * 10 / 100));
            }
        }


        actual_income_n = income_n - expense_n;

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
