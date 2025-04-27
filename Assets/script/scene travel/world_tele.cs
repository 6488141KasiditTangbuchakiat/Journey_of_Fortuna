using TMPro;
using UnityEngine;

public class world_tele : MonoBehaviour
{
    public GameObject final_UI;
    public GameObject warp;
    public GameObject summary;
    public gold_event gold;

    public statistics player;
    public tile_event te;

    public TextMeshProUGUI warp_txt;

    public AudioManager soundPlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.player_stage == 1)
        {
            warp_txt.SetText("คุณกำลังจะเข้าสู่ช่วงวัยทำงานแล้ว การเดินทางสู่ความสำเร็จในชีวิตกำลังจะเริ่มต้นขึ้น หลังจากนี้เป็นต้นไป");
        }
        else if (player.player_stage == 2)
        {
            warp_txt.SetText("คุณกำลังจะเข้าสู่ช่วงวัยทำงานตอนปลายแล้ว ตั้งใจทำงานเก็บเงินให้ดี แล้วตอนเกษียณจะสบายเอง เราขอให้คุณประสบความสำเร็จนะ");
        }
        else if (player.player_stage == 3)
        {
            warp_txt.SetText("คุณกำลังจะเข้าสู่ช่วงวัยที่ใกล้จะเกษียณแล้ว การเดินทางของคุณใกล้จะจบลงแล้ว");
        }
        else if ((player.player_stage == 4))
        {
            warp_txt.SetText("คุณได้เข้าสู่วัยเกษียณแล้ว จะมาดูผลลัพท์จากความพยายามทั้งหมดที่ผ่านมาของคุณกันเถอะ");
        }
    }

    public void tele_call()
    {
        final_UI.SetActive(true);
        soundPlayer.sound_Play("notification");

        if ((player.reserve_money >= player.reserve_money_max) && (player.player_stage == 2 || player.player_stage == 3))
        {
            player.reserve_threshold_reached++;
            gold.eventPopUp();
            summary.SetActive(false);
            warp.SetActive(false);
        }
        else
        {
            gold.shut();
            summary.SetActive(true);
            warp.SetActive(false);
        }


        te.popup_on = true;
    }
}
