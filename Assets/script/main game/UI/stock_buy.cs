using TMPro;
using UnityEngine;

public class stock_buy : MonoBehaviour
{
    public statistics player;

    public stock picked_stock;
    public int current_stock = 0;

    public TextMeshProUGUI stock_name;
    public TextMeshProUGUI total_price;
    public TextMeshProUGUI total_price_og;

    public GameObject buy_button;
    public GameObject sell_button;

    public GameObject arrow1;
    public GameObject arrow2;
    public GameObject arrow3;

    public TMP_InputField inputField;

    string s_name;
    int b_num = 0;
    int t_price;
    int t_price_og;

    bool recorded = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (inputField != null)
        {
            // Optional: Force to integer input via code
            inputField.contentType = TMP_InputField.ContentType.IntegerNumber;

            // Listen for changes
            inputField.onValueChanged.AddListener(ValidateInput);
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (picked_stock != null)
        {
            s_name = picked_stock.company_name;
            t_price = picked_stock.stock_price * b_num;

            if (current_stock == 1)
            {
                t_price_og = player.stock1og * b_num;

                arrow1.SetActive(true);
                arrow2.SetActive(false);
                arrow3.SetActive(false);
            }
            else if (current_stock == 2)
            {
                t_price_og = player.stock2og * b_num;

                arrow1.SetActive(false);
                arrow2.SetActive(true);
                arrow3.SetActive(false);
            }
            else if (current_stock == 3)
            {
                t_price_og = player.stock3og * b_num;

                arrow1.SetActive(false);
                arrow2.SetActive(false);
                arrow3.SetActive(true);
            }

            stock_name.SetText($"{s_name}");
            total_price.SetText($"มูลค่าหุ้นตอนนี้: {t_price.ToString("N0")}");
            total_price_og.SetText($"มูลค่าหุ้นของคุณ: {t_price_og.ToString("N0")}");


            //buy block
            if (t_price > player.money)
            {
                buy_button.SetActive(false);
            }
            else
            {
                buy_button.SetActive(true);
            }


            //sell block
            if (current_stock == 1)
            {
                if (b_num > player.stock1 || player.stock1 == 0)
                {
                    sell_button.SetActive(false);
                }
                else
                {
                    sell_button.SetActive(true);
                }
            }
            else if (current_stock == 2)
            {
                if (b_num > player.stock2 || player.stock2 == 0)
                {
                    sell_button.SetActive(false);
                }
                else
                {
                    sell_button.SetActive(true);
                }
            }
            else if (current_stock == 3)
            {
                if (b_num > player.stock3 || player.stock3 == 0)
                {
                    sell_button.SetActive(false);
                }
                else
                {
                    sell_button.SetActive(true);
                }
            }
        }
        else
        {
            buy_button.SetActive(false);
            sell_button.SetActive(false);
        }
    }

    public void pick_stock(stock new_stock)
    {
        picked_stock = new_stock;
    }

    public void stock_set(int i)
    {
        current_stock = i;
    }

    public void increase_b_num_by(int num)
    {
        b_num += num;

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

    public void b_num_max()
    {
        b_num = player.money / picked_stock.stock_price;

        change_input_to_b_num();
    }

    public void b_num_min()
    {
        b_num = 0;

        change_input_to_b_num();
    }

    public void buy_stock()
    {
        if (current_stock == 1)
        {
            player.stock1 += b_num;

            if (player.stock1og == 0)
            {
                player.stock1og = picked_stock.stock_price;
            }
            else
            {
                player.stock1og = (player.stock1og + picked_stock.stock_price) / 2;
            }

            player.loseMoney(t_price);
        }
        else if (current_stock == 2)
        {
            player.stock2 += b_num;

            if (player.stock2og == 0)
            {
                player.stock2og = picked_stock.stock_price;
            }
            else
            {
                player.stock2og = (player.stock2og + picked_stock.stock_price) / 2;
            }

            player.loseMoney(t_price);
        }
        else if (current_stock == 3)
        {
            player.stock3 += b_num;

            if (player.stock3og == 0)
            {
                player.stock3og = picked_stock.stock_price;
            }
            else
            {
                player.stock3og = (player.stock3og + picked_stock.stock_price) / 2;
            }

            player.loseMoney(t_price);
        }
    }

    public void sell_stock()
    {
        if (current_stock == 1)
        {
            player.stock1 -= b_num;

            if (player.stock1 == 0)
            {
                player.stock1og = 0;
            }

            player.addMoney(t_price);
        }
        else if (current_stock == 2)
        {
            player.stock2 -= b_num;

            if (player.stock2 == 0)
            {
                player.stock2og = 0;
            }

            player.addMoney(t_price);
        }
        else if (current_stock == 3)
        {
            player.stock3 -= b_num;

            if (player.stock3 == 0)
            {
                player.stock3og = 0;
            }

            player.addMoney(t_price);
        }

        if (t_price >= 100000 && recorded == false)
        {
            player.insert_record("profit from stock over 100,000 baht");

            recorded = true;
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
