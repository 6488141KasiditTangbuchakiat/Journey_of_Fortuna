using TMPro;
using UnityEngine;
using static partner.Job_type;

public class earning_cal : MonoBehaviour
{
    public TextMeshProUGUI income;
    public TextMeshProUGUI expense;

    public TextMeshProUGUI base_expense;
    public TextMeshProUGUI base_travel;
    public TextMeshProUGUI base_food;
    public TextMeshProUGUI base_rest;

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
        int movement_round = movement.pass_earn_num_and_reset();
        int payraise = player.pay_raise * player.myJob.job_raise;
        int income_n = (player.myJob.job_salary + payraise) * movement_round;
        int partner_income_n = 0;

        if (player.partner != null)
        {
            partner_income_n = player.partner.partner_salary * movement_round;
        }

        if (player.jobless_day > 0)
        {
            income_n = 0;
            player.jobless_day_pass();
        }

        if (player.p_fund_banned > 0)
        {
            player.p_fund_banned_pass();
        }

        if (player.p_fund_percentage > 0 && player.p_fund_banned == 0)
        {
            int pfund_money = income_n * player.p_fund_percentage / 100;

            income_n = income_n - pfund_money;
            player.add_p_fund(pfund_money);

        }

        int base_ex_n = 0;
        int base_food_n = player.myJob.job_expense_food;
        int base_travel_n = 0;
        int base_rest_n = 0;

        int house_n = 0;
        int car_n = 0;

        if (player.hasCar == null)
        {
            base_travel_n += player.myJob.job_expense_travel;
        }
        else if (player.car_debt > 0)
        {
            // calculate car interest
            car_n = calculator.x_in_y_percent(player.hasCar.mortgage, 5) + player.get_car_pay();

            if (player.car_debt == 0)
            {
                player.insert_record("คุณผ่อนรถหมดก่อนเข้าวัยเกษียณ ทำให้คุณมีเงินเหลือที่จะไปลงทุนต่อ");
            }
        }

        if (player.hasHouse == null)
        {
            base_rest_n += player.myJob.job_expense_housing;
        }
        else if (player.house_debt > 0)
        {
            // calculate house interest
            house_n = calculator.x_in_y_percent(player.hasHouse.mortgage, 5) + player.get_house_pay();

            if (player.house_debt == 0)
            {
                player.insert_record("คุณผ่อนบ้านหมดก่อนเข้าวัยเกษียณ ทำให้คุณมีเงินเหลือที่จะไปลงทุนต่อ");
            }
        }


        // calculate loan interest
        int loan_n = calculator.x_in_y_percent(player.loan_debt, 20);

        if (player.hasHouse != null)
        {
            player.house_debt -= player.get_house_pay();
        }
        if (player.hasCar != null)
        {
            player.car_debt -= player.get_car_pay();
        }


        // banker buff - mortgage discount
        if (player.partner != null)
        {
            if (player.partner.partner_job == Banker)
            {
                house_n = house_n - calculator.x_in_y_percent(house_n, 10);
                car_n = car_n - calculator.x_in_y_percent(car_n, 10);
                loan_n = loan_n - calculator.x_in_y_percent(loan_n, 10);
            }
        }


        int insur_n = 0;

        if (player.insurance_expire > 0)
        {
            if (player.life_insurance)
            {
                insur_n += life.price_from_age(player.age);
            }
            if (player.Accident_insurance.Count > 0)
            {
                insur_n += player.Accident_insurance[0].price_from_age(player.age);
            }
            if (player.Health_insurance.Count > 0)
            {
                insur_n += player.Health_insurance[0].price_from_age(player.age);
            }

            if (insur_n > 0)
            {
                player.count_insurance_day();
            }

            if (insur_n > player.money)
            {
                player.insurance_expire = 0;
                insur_n = 0;
            }
        }


        int child_n = player.child_cost();

        base_ex_n = base_food_n + base_travel_n + base_rest_n;

        int expense_n = base_ex_n + house_n + car_n + loan_n + insur_n + child_n;

        if (player.partner != null)
        {
            // partner businessperson buff

            if (player.partner.partner_job == BusinessPerson)
            {
                income_n = (int)(income_n + Mathf.Abs(calculator.x_in_y_percent(income_n, 10)));
            }
        }


        actual_income_n = income_n - expense_n;


        // setting texts

        income.SetText($"{income_n.ToString("N0")}");

        if (player.partner != null)
        {
            income.SetText($"{income_n.ToString("N0")} + แฟน {partner_income_n.ToString("N0")}");
            actual_income_n += partner_income_n;
        }

        expense.SetText($"{expense_n.ToString("N0")}");

        base_expense.SetText($"{base_ex_n.ToString("N0")}");
        base_travel.SetText($"{base_travel_n.ToString("N0")}");
        base_food.SetText($"{base_food_n.ToString("N0")}");
        base_rest.SetText($"{base_rest_n.ToString("N0")}");

        house.SetText($"{house_n.ToString("N0")}");
        car.SetText($"{car_n.ToString("N0")}");
        loan.SetText($"{loan_n.ToString("N0")}");

        // banker buff - mortgage discount
        if (player.partner != null)
        {
            if (player.partner.partner_job == Banker)
            {
                house.SetText($"{house_n.ToString("N0")} (ลด 10%)");
                car.SetText($"{car_n.ToString("N0")} (ลด 10%)");
                loan.SetText($"{loan_n.ToString("N0")} (ลด 10%)");
            }
        }



        child.SetText($"{child_n.ToString("N0")}");
        insur.SetText($"{insur_n.ToString("N0")}");
        actual_income.SetText($"{actual_income_n.ToString("N0")}");
    }

    public void receive_income()
    {
        // player.addMoney(actual_income_n);
    }
}
