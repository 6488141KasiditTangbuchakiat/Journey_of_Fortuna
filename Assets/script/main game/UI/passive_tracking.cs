using System.Diagnostics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class passive_tracking : MonoBehaviour
{
    public statistics player;

    public GameObject icon_salary_up;
    public GameObject icon_energy_up;
    public GameObject icon_deflation;
    public GameObject icon_permanent_cost_reduce;
    public GameObject icon_jobless;
    public GameObject icon_inflation;
    public GameObject icon_energy_no_regen;

    public TextMeshProUGUI passive_head;
    public TextMeshProUGUI passive_active;
    public TextMeshProUGUI passive_desc;

    public string active_text;
    public string inactive_text;

    public float opacity_disabled;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        get_more_salary();
    }

    // Update is called once per frame
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

    public void get_more_salary()
    {
        passive_head.SetText("ได้เลื่อนตำแหน่ง");
        passive_desc.SetText("ได้รับเงินเดือนเยอะขึ้น");

        if (player.pay_raise > 0)
        {
            passive_active.SetText(active_text);
        }
        else
        {
            passive_active.SetText(inactive_text);
        }
    }

    public void increase_energy_cap()
    {
        passive_head.SetText("พรแห่งพละกำลัง");
        passive_desc.SetText("ทำให้พลังงานสูงสุดเยอะขึ้น");

        if (player.energy_cap_buff > 0)
        {
            passive_active.SetText(active_text);
        }
        else
        {
            passive_active.SetText(inactive_text);
        }
    }

    public void deflation_cheaper()
    {
        passive_head.SetText("ภาวะเงินฝืด");
        passive_desc.SetText("ค่าใช้จ่ายราคาตกลง");

        if (player.deflation > 0)
        {
            passive_active.SetText(active_text);
        }
        else
        {
            passive_active.SetText(inactive_text);
        }
    }

    public void cheaper_from_gold_card()
    {
        passive_head.SetText("พรแห่งความประหยัด");
        passive_desc.SetText("ค่าใช้จ่ายราคาตกลง");

        if (player.cost_reduce_buff > 0)
        {
            passive_active.SetText(active_text);
        }
        else
        {
            passive_active.SetText(inactive_text);
        }
    }

    public void jobless_day()
    {
        passive_head.SetText("ตกงาน");
        passive_desc.SetText("ไม่สามารถได้รับเงินเดือนได้");

        if (player.jobless_day > 0)
        {
            passive_active.SetText(active_text);
        }
        else
        {
            passive_active.SetText(inactive_text);
        }
    }
    public void inflation_more_expensive()
    {
        passive_head.SetText("ภาวะเงินเฟ้อ");
        passive_desc.SetText("ค่าใช้จ่ายราคาสูงขึ้น");

        if (player.inflation > 0)
        {
            passive_active.SetText(active_text);
        }
        else
        {
            passive_active.SetText(inactive_text);
        }
    }
    public void no_energy_regen()
    {
        passive_head.SetText("หมดกำลัง");
        passive_desc.SetText("ไม่สามารถฟื้นพลังงานได้");

        if (player.energy_no_regen_cooldown > 0)
        {
            passive_active.SetText(active_text);
        }
        else
        {
            passive_active.SetText(inactive_text);
        }
    }
}
