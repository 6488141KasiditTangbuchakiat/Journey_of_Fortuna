using TMPro;
using UnityEngine;
using static insurance.tier;

public class insurance_panel : MonoBehaviour
{
    int change_made = 0;

    public statistics player;

    public TextMeshProUGUI life_upkeep;
    public TextMeshProUGUI accidentA_upkeep;
    public TextMeshProUGUI accidentS_upkeep;
    public TextMeshProUGUI healthA_upkeep;
    public TextMeshProUGUI healthS_upkeep;

    int cost_num;
    public TextMeshProUGUI cost;

    public insurance life;
    public insurance accidentA;
    public insurance accidentS;
    public insurance healthA;
    public insurance healthS;

    public bool has_life = false;
    public bool has_accidentA = false;
    public bool has_accidentS = false;
    public bool has_healthA = false;
    public bool has_healthS = false;

    public GameObject tick_l;
    public GameObject tick_aA;
    public GameObject tick_aS;
    public GameObject tick_hA;
    public GameObject tick_hS;

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

        if(player.Accident_insurance.Count > 0)
        {
            if (player.Accident_insurance[0].InTier == A)
            {
                p_has_accidentA = true;
            }
            else if (player.Accident_insurance[0].InTier == S)
            {
                p_has_accidentS = true;
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
            }
            else if (player.Health_insurance[0].InTier == S)
            {
                p_has_healthS = true;
            }
        }
        else
        {
            p_has_healthA = false;
            p_has_healthS = false;
        }


        life_upkeep.SetText($"{life.price}");
        accidentA_upkeep.SetText($"{accidentA.price}");
        accidentS_upkeep.SetText($"{accidentS.price}");
        healthA_upkeep.SetText($"{healthA.price}");
        healthS_upkeep.SetText($"{healthS.price}");

        bool check1 = p_has_life == has_life;
        bool check2 = p_has_accidentA == has_accidentA;
        bool check3 = p_has_accidentS == has_accidentS;
        bool check4 = p_has_healthA == has_healthA;
        bool check5 = p_has_healthS == has_healthS;

        if (cost_num > player.money || (check1 && check2 && check3 && check4 && check5))
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
        has_accidentA = false;
        has_accidentS = false;
        has_healthA = false;
        has_healthS = false;

        if (player.life_insurance)
        {
            has_life = true;
        }

        if (player.Accident_insurance.Count > 0)
        {
            if (player.Accident_insurance[0].InTier == S)
            {
                has_accidentS = true;
            }
            else if (player.Accident_insurance[0].InTier == A)
            {
                has_accidentA = true;
            }
        }

        if (player.Health_insurance.Count > 0)
        {
            if (player.Health_insurance[0].InTier == S)
            {
                has_healthS = true;
            }
            else if (player.Health_insurance[0].InTier == A)
            {
                has_healthA = true;
            }
        }

        tick_text_reset();
    }

    void tick_text_reset()
    {
        cost_num = 0;

        tick_l.SetActive(has_life);
        tick_aA.SetActive(has_accidentA);
        tick_aS.SetActive(has_accidentS);
        tick_hA.SetActive(has_healthA);
        tick_hS.SetActive(has_healthS);

        if (has_life)
        {
            cost_num += life.price;
        }
        if (has_accidentA)
        {
            cost_num += accidentA.price;
        }
        if (has_accidentS)
        {
            cost_num += accidentS.price;
        }
        if (has_healthA)
        {
            cost_num += healthA.price;
        }
        if (has_healthS)
        {
            cost_num += healthS.price;
        }

        cost.SetText($"ราคาทั้งหมด: {cost_num}");
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
        change_made++;
    }

    public void select_accident(int tier)
    {
        if (tier == 1)
        {
            if (has_accidentA)
            {
                has_accidentA = false;
            }
            else
            {
                has_accidentA = true;
                has_accidentS = false;
            }
        }
        else if (tier == 2)
        {
            if (has_accidentS)
            {
                has_accidentS = false;
            }
            else
            {
                has_accidentS = true;
                has_accidentA = false;
            }
        }

        tick_text_reset();
        change_made++;
    }

    public void select_health(int tier)
    {
        if (tier == 1)
        {
            if (has_healthA)
            {
                has_healthA = false;
            }
            else
            {
                has_healthA = true;
                has_healthS = false;
            }
        }
        else if (tier == 2)
        {
            if (has_healthS)
            {
                has_healthS = false;
            }
            else
            {
                has_healthS = true;
                has_healthA = false;
            }
        }

        tick_text_reset();
        change_made++;
    }

    public void confirm_purchase()
    {
        player.Accident_insurance.Clear();
        player.Health_insurance.Clear();


        // readd insurance from purchase
        if (has_life)
        {
            player.life_insurance = true;
        }
        else
        {
            player.life_insurance = false;
        }

        if (has_accidentA)
        {
            player.Accident_insurance.Add(accidentA);
        }
        else if (has_accidentS)
        {
            player.Accident_insurance.Add(accidentS);
        }

        if (has_healthA)
        {
            player.Health_insurance.Add(healthA);
        }
        else if (has_healthS)
        {
            player.Health_insurance.Add(healthS);
        }

        player.loseMoney(cost_num);
        change_made = 0;
    }
}
