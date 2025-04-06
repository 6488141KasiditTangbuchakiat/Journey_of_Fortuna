using UnityEngine;

public class oppo_p2_event : MonoBehaviour
{
    public GameObject event_panel;
    public oppo_p2_event_info event_text;

    public card _card;

    public statistics statistics;

    public tile_event popup_fixer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void eventPopUp()
    {
        popup_fixer.popup_on = true;
        event_panel.SetActive(true);
    }
}
