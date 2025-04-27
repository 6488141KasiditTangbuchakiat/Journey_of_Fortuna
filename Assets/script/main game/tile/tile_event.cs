using UnityEngine;

public class tile_event : MonoBehaviour
{
    oppo_event opportunity;
    greed_event greed;
    earn_event earn;
    news_event news;
    danger_event danger;
    love_event love;

    public doubleDice_button DDB;

    public AudioManager soundPlayer;

    public statistics player;

    public bool popup_on = false;

    public int news_chance = 50;
    public int love_chance = 25;
    public int danger_chance = 25;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        opportunity = GetComponent<oppo_event>();
        greed = GetComponent<greed_event>();
        earn = GetComponent<earn_event>();
        news = GetComponent<news_event>();
        danger = GetComponent<danger_event>();
        love = GetComponent<love_event>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void readTile(tile thisTile, bool pass_earn)
    {
        open_popup();
        soundPlayer.sound_Play("notification");

        if (pass_earn)
        {
            // call green, then whatever the player is standing on

            earn.eventPopUp();
            earn.assignTile(thisTile);
        }
        else
        {
            // tile type reading

            switch (thisTile.thisTileType)
            {
                case tile.tileType.Opportunity:

                    opportunity.eventPopUp();

                    break;

                case tile.tileType.Expense:

                    if (player.debug_mode == 1 && player.reserve_money > 5000)
                    {
                        greed.eventPopUp_debug_mode();

                        player.debug_mode = 0;
                    }
                    else
                    {
                        greed.eventPopUp();
                    }


                    break;

                case tile.tileType.Earning:

                    earn.eventPopUp();

                    break;

                case tile.tileType.EVENT:

                    if (player.debug_mode == 2 && (player.life_insurance || player.Accident_insurance != null || player.Health_insurance != null))
                    {
                        danger.eventPopUp();

                        player.debug_mode = 0;
                    }
                    else if (player.debug_mode == 3 && (player.stock1 > 0 || player.stock2 > 0 || player.stock3 > 0))
                    {
                        news.eventPopUp();
                    }
                    else
                    {
                        int num = Random.Range(0, news_chance + love_chance + danger_chance);

                        if (num >= 0 && num < news_chance && news_chance != 0)
                        {
                            // num >= 0 && num < 50
                            // 50%

                            news.eventPopUp();
                        }
                        else if (num >= news_chance && num < news_chance + danger_chance && danger_chance != 0)
                        {
                            // num >= 50 && num < 75
                            // 25 %

                            danger.eventPopUp();
                        }
                        else if (love_chance != 0)
                        {
                            // num >= 75 && num < 100
                            // x %

                            love.eventPopUp();
                        }
                    }



                    break;

                default:
                    break;
            }
        }
    }

    public void close_popup()
    {
        popup_on = false;
        DDB.make_button_appear();
    }

    public void open_popup()
    {
        popup_on = true;
        DDB.make_button_invis();
    }
}
