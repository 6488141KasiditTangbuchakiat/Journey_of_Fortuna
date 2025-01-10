using UnityEngine;

public class earn_event : MonoBehaviour
{
    public GameObject event_panel;

    public tile_event _tile_event;

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
    }

    public void assignTile(tile tile)
    {
        tile1 = tile;
    }

    public void call_next_event()
    {
        if (tile1 != null) { 
            _tile_event.readTile(tile1, false);
            tile1 = null;
        }
        
    }
}
