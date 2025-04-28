using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class earn_event : MonoBehaviour
{
    public GameObject event_panel;
    public earning_cal event_text;

    public tile_event _tile_event;

    public List<GameObject> all_panels = new List<GameObject>();
    public List<GameObject> all_buttons = new List<GameObject>();

    public statistics stats;

    tile tile1 = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _tile_event = GetComponent<tile_event>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void eventPopUp()
    {
        event_panel.SetActive(true);

        int counter = 0;
        foreach (GameObject i in all_panels)
        {
            if (counter == 0)
            {
                i.SetActive(true);
            }
            else
            {
                i.SetActive(false);
            }

            counter++;
        }

        foreach (GameObject i in all_buttons)
        {
            i.SetActive(true);
        }

        event_text.event_on_popup();
    }

    public void assignTile(tile tile)
    {
        tile1 = tile;
    }

    public void call_next_event()
    {
        if (tile1 != null)
        {
            _tile_event.readTile(tile1, false);
            tile1 = null;
        }

    }
}
