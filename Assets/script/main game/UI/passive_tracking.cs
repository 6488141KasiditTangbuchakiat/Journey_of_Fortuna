using System.Diagnostics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class passive_tracking : MonoBehaviour
{
    public statistics player;

    public TextMeshProUGUI passive_lv;
    public TextMeshProUGUI passive_desc;

    public GameObject desc_panel;

    public GameObject buff_icon1;
    public GameObject buff_icon2;
    public GameObject buff_icon3;

    public GameObject debuff_icon1;
    public GameObject debuff_icon2;
    public GameObject debuff_icon3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // get more salary(permanent)
        if (player.pay_raise > 0)
        {

        }

        // increase energy cap(25 energy, permanent) 
        if(player.energy_cap_buff > 0)
        {

        }

        // expense more cheap 5 % (turn cooldown)
        if(player.deflation > 0)
        {

        }

        // jobless day(turn cooldown)
        if(player.jobless_day > 0)
        {

        }

        // expense more expensive 5 % (turn cooldown) 
        if (player.inflation > 0)
        {

        }

        // no energy regen(turn cooldown)
        if(player.energy_no_regen_cooldown > 0)
        {

        }

    }

    void passive_buff1()
    {

    }

    void passive_buff2()
    {

    }

    void passive_buff3()
    {

    }

    void passive_debuff1()
    {

    }

    void passive_debuff2()
    {

    }

    void passive_debuff3()
    {

    }
}
