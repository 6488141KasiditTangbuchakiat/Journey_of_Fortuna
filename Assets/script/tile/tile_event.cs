using UnityEngine;

public class tile_event : MonoBehaviour
{
    oppo_event opportunity;
    greed_event greed;
    earn_event earn;
    news_event news;

    public bool popup_on = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        opportunity = GetComponent<oppo_event>();
        greed = GetComponent<greed_event>();
        earn = GetComponent<earn_event>();
        news = GetComponent<news_event>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void readTile(tile thisTile, bool pass_earn)
    {
        popup_on = true;

        if(pass_earn)
        {
            earn.eventPopUp();
            earn.assignTile(thisTile);
        }
        else
        {
            switch (thisTile.thisTileType)
            {
                case tile.tileType.Opportunity:

                    opportunity.eventPopUp();

                    break;

                case tile.tileType.Greed:

                    greed.eventPopUp();

                    break;

                case tile.tileType.Earning:

                    earn.eventPopUp();

                    break;

                case tile.tileType.NEWS:

                    news.eventPopUp();

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
}
