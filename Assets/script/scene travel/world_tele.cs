using UnityEngine;

public class world_tele : MonoBehaviour
{
    public GameObject final_UI;
    public GameObject warp;
    public GameObject summary;
    public gold_event gold;

    public statistics player;
    public tile_event te;

    public GlobalAudioManager soundPlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void tele_call()
    {
        final_UI.SetActive(true);
        soundPlayer.PlayClickSound();

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
