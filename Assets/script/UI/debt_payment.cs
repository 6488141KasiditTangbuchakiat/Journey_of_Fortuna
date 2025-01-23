using TMPro;
using UnityEngine;

public class debt_payment : MonoBehaviour
{
    public statistics player;

    public TextMeshProUGUI debt_name;
    public TextMeshProUGUI buy_num;

    public GameObject pay_button;

    int chosen_debt = 0;

    public int b_num = 0;
    int current_debt_num = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // keep buy num below debt cost

        if (b_num > current_debt_num)
        {
            b_num = current_debt_num;
        }

        buy_num.SetText($"{b_num}");

        // set chosen debt text
        if (chosen_debt == 1)
        {
            debt_name.SetText("paying: house");
            current_debt_num = player.house_debt;
        }
        else if (chosen_debt == 2)
        {
            debt_name.SetText("paying: car");
            current_debt_num = player.car_debt;
        }
        else if (chosen_debt == 3)
        {
            debt_name.SetText("paying: loan");
            current_debt_num = player.loan_debt;
        }

        // payment block
        if (chosen_debt == 0)
        {
            pay_button.SetActive(false);
        }
        else
        {
            if (b_num > player.money)
            {
                pay_button.SetActive(false);
            }
            else
            {
                pay_button.SetActive(true);
            }
        }
    }

    public void increase_b_num_by(int num)
    {
        b_num += num;
    }

    public void decrease_b_num_by(int num)
    {
        b_num -= num;

        if (b_num < 0)
        {
            b_num = 0;
        }
    }

    public void b_num_min()
    {
        b_num = 0;
    }

    public void b_num_max()
    {
        if (chosen_debt == 1)
        {
            b_num = player.house_debt;
        }
        else if (chosen_debt == 2)
        {
            b_num = player.car_debt;
        }
        else if (chosen_debt == 3)
        {
            b_num = player.loan_debt;
        }

    }

    public void pick_debt(int num)
    {
        chosen_debt = num;
    }

    public void paying_debt()
    {
        if (chosen_debt == 1)
        {
            player.loseMoney(b_num);
            player.reduceHouseDebt(b_num);
        }
        else if (chosen_debt == 2)
        {
            player.loseMoney(b_num);
            player.reduceCarDebt(b_num);
        }
        else if (chosen_debt == 3)
        {
            player.loseMoney(b_num);
            player.reduceLoan(b_num);
        }
    }
}
