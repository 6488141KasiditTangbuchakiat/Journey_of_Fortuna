using UnityEngine;

public class world_tele : MonoBehaviour
{
    public GameObject final_UI;
    public tile_event te;

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
        te.popup_on = true;
    }
}
