using TMPro;
using UnityEngine;
using static partner;

public class lover_slot : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public statistics player_stats;
    public partner thisPartner;

    public TextMeshProUGUI lover_job;



    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lover_job.SetText($"{thisPartner.partner_job}");
    }

    public void addLover()
    {
        player_stats.partner = thisPartner;
    }
}
