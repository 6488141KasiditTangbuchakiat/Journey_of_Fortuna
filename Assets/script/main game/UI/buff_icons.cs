using UnityEngine;

public class buff_icons : MonoBehaviour
{
    public statistics player;

    public GameObject icon_salary_up;
    public GameObject icon_energy_up;
    public GameObject icon_deflation;
    public GameObject icon_permanent_cost_reduce;
    public GameObject icon_jobless;
    public GameObject icon_inflation;
    public GameObject icon_energy_no_regen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void FixedUpdate()
    {

        // get more salary (permanent)
        if (player.pay_raise > 0)
        {
            icon_salary_up.SetActive(true);
        }
        else
        {
            icon_salary_up.SetActive(false);
        }

        // increase energy cap (25 energy, permanent) 
        if (player.energy_cap_buff > 0)
        {
            icon_energy_up.SetActive(true);
        }
        else
        {
            icon_energy_up.SetActive(false);
        }

        // deflation cheaper
        if (player.deflation > 0)
        {
            icon_deflation.SetActive(true);
        }
        else
        {
            icon_deflation.SetActive(false);
        }

        // cheaper from gold card (permanent)
        if(player.cost_reduce_buff > 0)
        {
            icon_permanent_cost_reduce.SetActive(true);
        }
        else
        {
            icon_permanent_cost_reduce.SetActive(false);
        }

        // jobless day (turn cooldown)
        if (player.jobless_day > 0)
        {
            icon_jobless.SetActive(false);
        }
        else
        {
            icon_jobless.SetActive(false);
        }

        // inflation more expensive
        if (player.inflation > 0)
        {
            icon_inflation.SetActive(true);
        }
        else
        {
            icon_inflation.SetActive(false);
        }

        // no energy regen (turn cooldown)
        if (player.energy_no_regen_cooldown > 0)
        {
            icon_energy_no_regen.SetActive(false);
        }
        else
        {
            icon_energy_no_regen.SetActive(false);
        }
    }
}
