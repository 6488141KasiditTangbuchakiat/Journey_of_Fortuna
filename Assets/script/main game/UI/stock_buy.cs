using TMPro;
using UnityEngine;

public class stock_buy : MonoBehaviour
{
    public statistics player;

    public stock picked_stock;
    public int current_stock = 0;

    public TextMeshProUGUI stock_name;
    public TextMeshProUGUI buy_num;
    public TextMeshProUGUI total_price;

    public GameObject buy_button;
    public GameObject sell_button;

    string s_name;
    int b_num = 0;
    int t_price;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (picked_stock != null)
        {
            s_name = picked_stock.company_name;
            t_price = picked_stock.stock_price * b_num;

            stock_name.SetText($"{s_name}");
            buy_num.SetText($"{b_num}");
            total_price.SetText($"Total price: {t_price}");


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
    }

    public void decrease_b_num_by(int num)
    {
        b_num -= num;

        if (b_num < 0)
        {
            b_num = 0;
        }
    }

    public void buy_stock()
    {
        if (current_stock == 1)
        {
            player.stock1 += b_num;
            player.loseMoney(t_price);
        }
        else if (current_stock == 2)
        {
            player.stock2 += b_num;
            player.loseMoney(t_price);
        }
        else if (current_stock == 3)
        {
            player.stock3 += b_num;
            player.loseMoney(t_price);
        }
    }

    public void sell_stock()
    {
        if (current_stock == 1)
        {
            player.stock1 -= b_num;
            player.addMoney(t_price);
        }
        else if (current_stock == 2)
        {
            player.stock2 -= b_num;
            player.addMoney(t_price);
        }
        else if (current_stock == 3)
        {
            player.stock3 -= b_num;
            player.addMoney(t_price);
        }
    }
}
