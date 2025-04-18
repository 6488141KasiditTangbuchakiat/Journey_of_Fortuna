using TMPro;
using UnityEngine;

public class debt_payment : MonoBehaviour
{
    public statistics player;

    public TextMeshProUGUI debt_name;
    public TextMeshProUGUI buy_num;

    public GameObject pay_button;

    public GameObject choose1;
    public GameObject choose2;
    public GameObject choose3;

    public TMP_InputField inputField;

    int chosen_debt = 1;

    public int b_num = 0;
    int current_debt_num = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Optional: Force to integer input via code
        inputField.contentType = TMP_InputField.ContentType.IntegerNumber;

        // Listen for changes
        inputField.onValueChanged.AddListener(ValidateInput);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // keep buy num below debt cost

        if (b_num > current_debt_num)
        {
            b_num = current_debt_num;
            change_input_to_b_num();
        }

        buy_num.SetText($"{b_num.ToString("N0")}");

        // set chosen debt text
        if (chosen_debt == 1)
        {
            debt_name.SetText("คุณเลือกจ่าย: ยอดเงินผ่อนบ้าน");
            current_debt_num = player.house_debt;

            choose1.SetActive(true);
            choose2.SetActive(false);
            choose3.SetActive(false);
        }
        else if (chosen_debt == 2)
        {
            debt_name.SetText("คุณเลือกจ่าย: ยอดเงินผ่อนรถ");
            current_debt_num = player.car_debt;

            choose1.SetActive(false);
            choose2.SetActive(true);
            choose3.SetActive(false);
        }
        else if (chosen_debt == 3)
        {
            debt_name.SetText("คุณเลือกจ่าย: หนี้เงินกู้");
            current_debt_num = player.loan_debt;

            choose1.SetActive(false);
            choose2.SetActive(false);
            choose3.SetActive(true);
        }

        // payment block
        if (chosen_debt == 0 || b_num == 0)
        {
            pay_button.SetActive(false);
        }
        else
        {
            if (b_num > player.money || current_debt_num <= 0)
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
        if (chosen_debt == 1 && b_num < player.house_debt)
        {
            b_num += num;
        }
        else if (chosen_debt == 2 && b_num < player.car_debt)
        {
            b_num += num;
        }
        else if (chosen_debt == 3 && b_num < player.loan_debt)
        {
            b_num += num;
        }


        change_input_to_b_num();
    }

    public void decrease_b_num_by(int num)
    {
        b_num -= num;

        if (b_num < 0)
        {
            b_num = 0;
        }

        change_input_to_b_num();
    }

    public void b_num_min()
    {
        b_num = 0;

        change_input_to_b_num();
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

        change_input_to_b_num();
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

            if(player.house_debt == 0)
            {
                player.insert_record("คุณผ่อนบ้านหมดก่อนเข้าวัยเกษียณ ทำให้คุณมีเงินเหลือที่จะไปลงทุนต่อ");
            }
        }
        else if (chosen_debt == 2)
        {
            player.loseMoney(b_num);
            player.reduceCarDebt(b_num);

            if (player.car_debt == 0)
            {
                player.insert_record("คุณผ่อนรถหมดก่อนเข้าวัยเกษียณ ทำให้คุณมีเงินเหลือที่จะไปลงทุนต่อ");
            }
        }
        else if (chosen_debt == 3)
        {
            player.loseMoney(b_num);
            player.reduceLoan(b_num);
        }
    }

    void ValidateInput(string value)
    {
        // Extra layer: Remove non-numeric characters if needed
        string result = "";
        foreach (char c in value)
        {
            if (char.IsDigit(c))
                result += c;
        }

        if (result != value)
        {
            inputField.text = result; // Sanitize input
        }

        if (inputField.text == "")
        {
            inputField.text = "0";
        }

        b_num = int.Parse(inputField.text);
    }

    void change_input_to_b_num()
    {
        inputField.text = b_num.ToString();
    }
}
