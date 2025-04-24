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

    public bool has_life = false;
    public int has_accident = 0;
    public int has_health = 0;

    int accidentHealth = 0;

    public GameObject tick_l;
    public GameObject tick_aA;
    public GameObject tick_hA;

    public GameObject confirm_button;

    bool p_has_life;
    bool p_has_accidentA;
    bool p_has_accidentS;
    bool p_has_healthA;
    bool p_has_healthS;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // check player inventory

        if (player.life_insurance)
        {
            p_has_life = true;
        }
        else
        {
            p_has_life = false;
        }

        if (player.Accident_insurance.Count > 0)
        {
            if (player.Accident_insurance[0].InTier == A)
            {
                p_has_accidentA = true;
                p_has_accidentS = false;
            }
            else if (player.Accident_insurance[0].InTier == S)
            {
                p_has_accidentS = true;
                p_has_accidentA = false;
            }
        }
        else
        {
            p_has_accidentA = false;
            p_has_accidentS = false;
        }

        if (player.Health_insurance.Count > 0)
        {
            if (player.Health_insurance[0].InTier == A)
            {
                p_has_healthA = true;
                p_has_healthS = false;
            }
            else if (player.Health_insurance[0].InTier == S)
            {
                p_has_healthS = true;
                p_has_healthA = false;
            }
        }
        else
        {
            p_has_healthA = false;
            p_has_healthS = false;
        }


        life_upkeep.SetText($"{life.price_from_age(player.age).ToString("N0")}");

        if (has_accident == 0)
        {
            accident_upkeep.SetText($"{accidentA.price_from_age(player.age).ToString("N0")}");
        }
        else if (has_accident == 1)
        {
            accident_upkeep.SetText($"{accidentA.price_from_age(player.age).ToString("N0")} (วงเงินต่ำ)");
        }
        else if (has_accident == 2)
        {
            accident_upkeep.SetText($"{accidentS.price_from_age(player.age).ToString("N0")} (วงเงินสูง)");
        }


        if (has_health == 0)
        {
            health_upkeep.SetText($"{healthA.price_from_age(player.age).ToString("N0")}");
        }
        else if (has_health == 1)
        {
            health_upkeep.SetText($"{healthA.price_from_age(player.age).ToString("N0")} (วงเงินต่ำ)");
        }
        else if (has_health == 2)
        {
            health_upkeep.SetText($"{healthS.price_from_age(player.age).ToString("N0")} (วงเงินสูง)");
        }

        year_count.SetText($"{year_num}");



        // buy check

        bool check1 = p_has_life == has_life;



        bool check2 = true;

        if (has_accident == 0)
        {
            if (!p_has_accidentA && !p_has_accidentS)
            {
                check2 = true;
            }
            else
            {
                check2 = false;
            }
        }
        else if (has_accident == 1)
        {
            if (p_has_accidentA && !p_has_accidentS)
            {
                check2 = true;
            }
            else
            {
                check2 = false;
            }
        }
        else if (has_accident == 2)
        {
            if (!p_has_accidentA && p_has_accidentS)
            {
                check2 = true;
            }
            else
            {
                check2 = false;
            }
        }


        bool check3 = true;

        if (has_health == 0)
        {
            if (!p_has_healthA && !p_has_healthS)
            {
                check3 = true;
            }
            else
            {
                check3 = false;
            }
        }
        else if (has_health == 1)
        {
            if (p_has_healthA && !p_has_healthS)
            {
                check3 = true;
            }
            else
            {
                check2 = false;
            }
        }
        else if (has_health == 2)
        {
            if (!p_has_healthA && p_has_healthS)
            {
                check3 = true;
            }
            else
            {
                check3 = false;
            }
        }


        bool check6 = year_num == player.insurance_expire;

        if (cost_num > player.money || (check1 && check2 && check3 && check6))
        {
            confirm_button.SetActive(false);
        }
        else
        {
            confirm_button.SetActive(true);
        }


    }

    public void insurance_status()
    {
        has_life = false;
        has_accident = 0;
        has_health = 0;

        if (player.life_insurance)
        {
            has_life = true;
        }

        if (player.Accident_insurance.Count > 0)
        {
            if (player.Accident_insurance[0].InTier == S)
            {
                has_accident = 2;
            }
            else if (player.Accident_insurance[0].InTier == A)
            {
                has_accident = 1;
            }
        }

        if (player.Health_insurance.Count > 0)
        {
            if (player.Health_insurance[0].InTier == S)
            {
                has_health = 2;
            }
            else if (player.Health_insurance[0].InTier == A)
            {
                has_health = 1;
            }
        }

        tick_text_reset();
    }

    void tick_text_reset()
    {
        cost_num = 0;

        // tick check

        tick_l.SetActive(has_life);

        if (has_accident == 0)
        {
            tick_aA.SetActive(false);
        }
        else if (has_accident == 1)
        {
            tick_aA.SetActive(true);
        }
        else if (has_accident == 2)
        {
            tick_aA.SetActive(true);
        }

        if (has_health == 0)
        {
            tick_hA.SetActive(false);
        }
        else if (has_health == 1)
        {
            tick_hA.SetActive(true);
        }
        else if (has_health == 2)
        {
            tick_hA.SetActive(true);
        }


        if (has_life)
        {
            cost_num += life.price_from_age(player.age);
        }
        if (has_accident == 1)
        {
            cost_num += accidentA.price_from_age(player.age);
        }
        if (has_accident == 2)
        {
            cost_num += accidentS.price_from_age(player.age);
        }
        if (has_health == 1)
        {
            cost_num += healthA.price_from_age(player.age);
        }
        if (has_health == 2)
        {
            cost_num += healthS.price_from_age(player.age);
        }

        cost.SetText($"{cost_num.ToString("N0")}");
    }

    public void select_life()
    {
        if (has_life)
        {
            has_life = false;
        }
        else
        {
            has_life = true;
        }

        tick_text_reset();

        accidentHealth = 0;
    }

    public void select_accident()
    {
        if(has_accident == 0)
        {
            has_accident = 1;
        }
        else
        {
            has_accident = 0;
        }

        tick_text_reset();

        accidentHealth = 1;
    }

    public void select_health()
    {
        if (has_health == 0)
        {
            has_health = 1;
        }
        else
        {
            has_health = 0;
        }

        tick_text_reset();

        accidentHealth = 2;
    }

    public void select_tier(int tier)
    {
        if (tier == 1)
        {
            if (accidentHealth == 1)
            {
                has_accident = 1;
            }
            else if (accidentHealth == 2)
            {
                has_health = 1;
            }
        }else if (tier == 2)
        {
            if (accidentHealth == 1)
            {
                has_accident = 2;
            }
            else if (accidentHealth == 2)
            {
                has_health = 2;
            }
        }

        tick_text_reset();

    }



    public void confirm_purchase()
    {
        int old_cost = insurance_price_cal();

        player.Accident_insurance.Clear();
        player.Health_insurance.Clear();


        // read insurance from purchase
        if (has_life)
        {
            player.life_insurance = true;
        }
        else
        {
            player.life_insurance = false;
        }

        if (has_accident == 1)
        {
            player.Accident_insurance.Add(accidentA);
        }
        else if (has_accident == 2)
        {
            player.Accident_insurance.Add(accidentS);
        }

        if (has_health == 1)
        {
            player.Health_insurance.Add(healthA);
        }
        else if (has_health == 2)
        {
            player.Health_insurance.Add(healthS);
        }

        int all_cost = cost_num - old_cost;

        if (all_cost < 0)
        {
            all_cost = 0;
        }

        player.loseMoney(all_cost);
        player.insurance_expire = year_num;
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
