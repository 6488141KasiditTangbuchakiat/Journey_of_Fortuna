using TMPro;
using UnityEngine;

public class loan_notification : MonoBehaviour
{
    public GameObject loan_panel;
    public TextMeshProUGUI loan_text;
    public GameObject exit_button;
    public GameObject stock_panel;

    public statistics player;
    public tile_event te;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.borrowed_money > 0 && !te.popup_on)
        {
            panel_active();
        }

        if(player.player_stage == 2 || player.player_stage == 3 || player.player_stage == 4)
        {
            stock_panel.SetActive(true);
        }
        else
        {
            stock_panel.SetActive(false);
        }


        if ((player.stock1 > 0 || player.stock2 > 0 || player.stock3 > 0) && player.money <= 0)
        {
            exit_button.SetActive(false);
        }
        else
        {
            exit_button.SetActive(true);
        }
    }

    public void panel_active()
    {
        int loan = player.borrowed_money;
        loan_panel.SetActive(true);
        loan_text.SetText($"ตอนนี้คุณเป็นหนี้อยู่ {loan.ToString("N0")} บาท รีบจ่ายด่วน");

        te.open_popup();

    }

    public void reset_panel()
    {
        player.borrowed_money = 0;
    }
}
