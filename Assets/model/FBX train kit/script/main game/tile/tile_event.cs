using UnityEngine;

public class tile_event : MonoBehaviour
{
    oppo_event opportunity;
    greed_event greed;
    earn_event earn;
    news_event news;
    danger_event danger;
    love_event love;

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
        popup_on = true;

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

                    greed.eventPopUp();

                    break;

                case tile.tileType.Earning:

                    earn.eventPopUp();

                    break;

                case tile.tileType.EVENT:

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

                    break;

                default:
                    break;
            }
        }
    }

    public void close_popup()
    {
        popup_on = false;
    }

    public void open_popup()
    {
        popup_on = true;
    }
}
