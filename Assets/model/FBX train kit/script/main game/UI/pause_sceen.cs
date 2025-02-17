using UnityEngine;

public class pause_sceen : MonoBehaviour
{
    public tile_event popup;
    public GameObject pause_UI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pause_game()
    {
        if(popup.popup_on == false)
        {
            pause_UI.SetActive(true);
            popup.popup_on = true;
        }
    }

    public void resume_game()
    {
        pause_UI.SetActive(false);
        popup.popup_on = false;
    }
}
