using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

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

    public float opacity_disabled;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void FixedUpdate()
    {

        // get more salary (permanent)
        if (player.pay_raise > 0)
        {
            icon_salary_up.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            icon_salary_up.GetComponent<Image>().color = new Color(1f, 1f, 1f, opacity_disabled);
        }

        // increase energy cap (25 energy, permanent) 
        if (player.energy_cap_buff > 0)
        {
            icon_energy_up.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            icon_energy_up.GetComponent<Image>().color = new Color(1f, 1f, 1f, opacity_disabled);
        }

        // deflation cheaper
        if (player.deflation > 0)
        {
            icon_deflation.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            icon_deflation.GetComponent<Image>().color = new Color(1f, 1f, 1f, opacity_disabled);
        }

        // cheaper from gold card (permanent)
        if (player.cost_reduce_buff > 0)
        {
            icon_permanent_cost_reduce.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            icon_permanent_cost_reduce.GetComponent<Image>().color = new Color(1f, 1f, 1f, opacity_disabled);
        }

        // jobless day (turn cooldown)
        if (player.jobless_day > 0)
        {
            icon_jobless.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            icon_jobless.GetComponent<Image>().color = new Color(1f, 1f, 1f, opacity_disabled);
        }

        // inflation more expensive
        if (player.inflation > 0)
        {
            icon_inflation.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            icon_inflation.GetComponent<Image>().color = new Color(1f, 1f, 1f, opacity_disabled);
        }

        // no energy regen (turn cooldown)
        if (player.energy_no_regen_cooldown > 0)
        {
            icon_energy_no_regen.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            icon_energy_no_regen.GetComponent<Image>().color = new Color(1f, 1f, 1f, opacity_disabled);
        }
    }
}
