using UnityEngine;

public class tile_event : MonoBehaviour
{
    oppo_event opportunity;
    greed_event greed;
    earn_event earn;

    public bool popup_on = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        opportunity = GetComponent<oppo_event>();
        greed = GetComponent<greed_event>();
        earn = GetComponent<earn_event>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void readTile(tile thisTile)
    {
        popup_on = true;

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

            default:
                break;
        }
    }

    public void close_popup()
    {
        popup_on = false;
    }
}
