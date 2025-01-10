using UnityEngine;

public class oppo_event : MonoBehaviour
{

    public GameObject event_panel;

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
        event_panel.SetActive(true);
    }
}
