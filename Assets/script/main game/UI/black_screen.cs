using UnityEngine;

public class black_screen : MonoBehaviour
{
    public GameObject black_panel;

    public tile_event te;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(te.popup_on)
        {
            black_panel.SetActive(true);
        }
        else
        {
            black_panel.SetActive(false);
        }
    }
}
