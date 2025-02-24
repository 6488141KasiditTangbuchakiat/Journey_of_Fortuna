using TMPro;
using UnityEngine;

public class jobless_panel : MonoBehaviour
{
    public statistics player;
    public TextMeshProUGUI text;
    public GameObject panel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(player.jobless_day > 0)
        {
            panel.SetActive(true);
            text.SetText($"jobless for {player.jobless_day} days");
        }
        else
        {
            panel.SetActive(false);
        }

        
    }
}
