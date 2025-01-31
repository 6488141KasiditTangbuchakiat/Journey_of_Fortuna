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

    public insurance life;

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
        int partner_income_n = 0;

        if (player.partner != null)
        {
            partner_income_n = player.partner.partner_salary;
        }

        if (player.jobless_day > 0)
        {
            income_n = 0;
            player.jobless_day_pass();
        }

        if (player.p_fund_percentage > 0)
        {
            int pfund_money = income_n * player.p_fund_percentage / 100;

            income_n = income_n - pfund_money;
            player.add_p_fund(pfund_money);

        }


        int house_n = calculator.x_in_y_percent(player.house_debt, 5);
        int car_n = calculator.x_in_y_percent(player.car_debt, 3);
        int loan_n = calculator.x_in_y_percent(player.loan_debt, 10);

        // banker buff - mortgage discount
        if(player.partner != null)
        {
            if(player.partner.partner_job == Banker)
            {
                house_n = house_n - calculator.x_in_y_percent(house_n, 10);
                car_n = car_n - calculator.x_in_y_percent(car_n, 10);
                loan_n = loan_n - calculator.x_in_y_percent(loan_n, 10);
            }
        }


        int insur_n = 0;
        if (player.life_insurance)
        {
            insur_n += life.price;
        }
        if (player.Accident_insurance.Count > 0)
        {
            insur_n += player.Accident_insurance[0].price;
        }
        if (player.Health_insurance.Count > 0)
        {
            insur_n += player.Health_insurance[0].price;
        }

        int child_n = player.child_cost();

        int expense_n = house_n + car_n + loan_n + insur_n + child_n;

        if (player.partner != null)
        {
            // partner businessperson buff

            if (player.partner.partner_job == BusinessPerson)
            {
                income_n = (int)(income_n + Mathf.Abs(calculator.x_in_y_percent(income_n, 10)));
            }
        }


        actual_income_n = income_n - expense_n;



        income.SetText($"{income_n}");

        if (player.partner != null)
        {
            income.SetText($"{income_n} + แฟน {partner_income_n}");
            actual_income_n += partner_income_n;
        }

        expense.SetText($"{expense_n}");

        house.SetText($"{house_n}");
        car.SetText($"{car_n}");
        loan.SetText($"{loan_n}");

        // banker buff - mortgage discount
        if (player.partner != null)
        {
            if (player.partner.partner_job == Banker)
            {
                house.SetText($"{house_n} (10% discount)");
                car.SetText($"{car_n} (10% discount)");
                loan.SetText($"{loan_n} (10% discount)");
            }
        }



        child.SetText($"{child_n}");
        insur.SetText($"{insur_n}");
        actual_income.SetText($"{actual_income_n}");
    }
}
