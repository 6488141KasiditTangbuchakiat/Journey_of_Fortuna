using TMPro;
using UnityEngine;

public class pfund_panel : MonoBehaviour
{
    public statistics player;

    public TextMeshProUGUI pfund_per;
    public TextMeshProUGUI pfund_saving;
    public TextMeshProUGUI pfund_per_current;
    public TextMeshProUGUI pfund_banned;

    public GameObject pfund_button;

    int pfund_set_percent = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        pfund_per.SetText($"{pfund_set_percent}%");
        pfund_saving.SetText($"{player.p_fund} บาท");
        pfund_per_current.SetText($"{player.p_fund_percentage}%");

        if(player.p_fund == 0)
        {
            pfund_button.SetActive(false);
        }
        else
        {
            pfund_button.SetActive(true);
        }

        if(player.p_fund_banned > 0)
        {
            pfund_banned.SetText($"{player.p_fund_banned} ช่องเขียวจนกว่าจะปลด");
        }
        else
        {
            pfund_banned.SetText($"");
        }
        
    }

    public void add_pfund()
    {
        if(pfund_set_percent < 15)
        {
            pfund_set_percent++;
        }
    }

    public void reduce_pfund()
    {
        if( pfund_set_percent > 0)
        {
            pfund_set_percent--;
        }
    }

    public void confirm_pfund()
    {
        player.p_fund_percentage = pfund_set_percent;
    }
}
