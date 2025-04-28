using TMPro;
using UnityEngine;
using static insurance.tier;

public class insurance_panel : MonoBehaviour
{

    public statistics player;

    public TextMeshProUGUI life_upkeep;
    public TextMeshProUGUI accident_upkeep;
    public TextMeshProUGUI health_upkeep;

    int cost_num;
    public TextMeshProUGUI cost;

    int year_num = 0;
    public TextMeshProUGUI year_count;

    public insurance life;
    public insurance accidentA;
    public insurance accidentS;
    public insurance healthA;
    public insurance healthS;

    // choosing insurance
    public int chosen_ins = 0;
    public int chosen_tier = 0;

    public GameObject tick_l;
    public GameObject tick_aA;
    public GameObject tick_hA;

    public GameObject confirm_button;

    public GameObject buy_notification;
    public TextMeshProUGUI buy_txt;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        select_ins(0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // tick check

        if (chosen_ins == 0)
        {
            tick_l.SetActive(true);
            tick_aA.SetActive(false);
            tick_hA.SetActive(false);
        }
        else if (chosen_ins == 1)
        {
            tick_l.SetActive(false);
            tick_aA.SetActive(true);
            tick_hA.SetActive(false);
        }
        else if (chosen_ins == 2)
        {
            tick_l.SetActive(false);
            tick_aA.SetActive(false);
            tick_hA.SetActive(true);
        }

        life_upkeep.SetText($"{life.price_from_age(player.age).ToString("N0")}");

        if (chosen_ins != 1)
        {
            accident_upkeep.SetText($"{accidentA.price_from_age(player.age).ToString("N0")}");
        }
        else if (chosen_ins == 1 && chosen_tier == 0)
        {
            accident_upkeep.SetText($"{accidentA.price_from_age(player.age).ToString("N0")} (วงเงินต่ำ)");
        }
        else if (chosen_ins == 1 && chosen_tier == 1)
        {
            accident_upkeep.SetText($"{accidentS.price_from_age(player.age).ToString("N0")} (วงเงินสูง)");
        }


        if (chosen_ins != 2)
        {
            health_upkeep.SetText($"{healthA.price_from_age(player.age).ToString("N0")}");
        }
        else if (chosen_ins == 2 && chosen_tier == 0)
        {
            health_upkeep.SetText($"{healthA.price_from_age(player.age).ToString("N0")} (วงเงินต่ำ)");
        }
        else if (chosen_ins == 2 && chosen_tier == 1)
        {
            health_upkeep.SetText($"{healthS.price_from_age(player.age).ToString("N0")} (วงเงินสูง)");
        }

        year_count.SetText($"{year_num}");


        if (cost_num > player.money || year_num == 0)
        {
            confirm_button.SetActive(false);
        }
        else
        {
            confirm_button.SetActive(true);
        }


    }

    void tick_text_reset()
    {
        cost_num = 0;

        if (chosen_ins == 0)
        {
            cost_num += life.price_from_age(player.age);
        }
        else if (chosen_ins == 1 && chosen_tier == 0)
        {
            cost_num += accidentA.price_from_age(player.age);
        }
        else if (chosen_ins == 1 && chosen_tier == 1)
        {
            cost_num += accidentS.price_from_age(player.age);
        }
        else if (chosen_ins == 2 && chosen_tier == 0) 
        {
            cost_num += healthA.price_from_age(player.age);
        }
        else if (chosen_ins == 2 && chosen_tier == 1)
        {
            cost_num += healthS.price_from_age(player.age);
        }

        cost.SetText($"{cost_num.ToString("N0")}");
    }

    public void select_ins(int i)
    {
        chosen_ins = i;

        tick_text_reset();

    }

    public void select_tier(int tier)
    {
        if (chosen_ins != 1)
        {
            chosen_tier = tier;
        }


        tick_text_reset();

    }



    public void confirm_purchase()
    {
        string ins_text = "";

        // read insurance from purchase
        if (chosen_ins == 0)
        {
            player.life_insurance = true;

            player.insurance_expire = year_num;

            ins_text = "ชีวิต";
        }

        else if (chosen_ins == 1 && chosen_tier == 0)
        {
            player.Accident_insurance.Clear();
            player.Accident_insurance.Add(accidentA);

            player.insurance_expire_a = year_num;

            ins_text = "อุบัติเหตุวงเงินต่ำ";
        }
        else if (chosen_ins == 1 && chosen_tier == 1)
        {
            player.Accident_insurance.Clear();
            player.Accident_insurance.Add(accidentS);

            player.insurance_expire_a = year_num;

            ins_text = "อุบัติเหตุวงเงินสูง";
        }

        else if (chosen_ins == 2 && chosen_tier == 0)
        {
            player.Health_insurance.Clear();
            player.Health_insurance.Add(healthA);

            player.insurance_expire_h = year_num;

            ins_text = "สุขภาพวงเงินต่ำ";
        }
        else if (chosen_ins == 2 && chosen_tier == 1)
        {
            player.Health_insurance.Clear();
            player.Health_insurance.Add(healthS);

            player.insurance_expire_h = year_num;

            ins_text = "สุขภาพวงเงินสูง";
        }

        player.loseMoney(cost_num);


        buy_notification.SetActive(true);
        buy_txt.SetText($"คุณได้ซื้อประกัน{ins_text} เป็นเวลา {year_num} ปี");

        year_num = 0;

    }

    public int insurance_price_cal()
    {
        int cost = 0;

        if (player.life_insurance)
        {
            cost += life.price_from_age(player.age);
        }
        if (player.Accident_insurance.Count > 0)
        {
            cost += player.Accident_insurance[0].price_from_age(player.age);
        }
        if (player.Health_insurance.Count > 0)
        {
            cost += player.Health_insurance[0].price_from_age(player.age);
        }

        return cost;
    }

    public void increase_year()
    {
        year_num++;
    }

    public void decrease_year()
    {
        year_num--;

        if (year_num < 0)
        {
            year_num = 0;
        }
    }

}
