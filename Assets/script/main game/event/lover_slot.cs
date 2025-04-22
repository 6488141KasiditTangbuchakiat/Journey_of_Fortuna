using TMPro;
using UnityEngine;
using static partner;

public class lover_slot : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public statistics player_stats;
    public partner thisPartner;

    public bool show_info = false;
    public GameObject partner_information;
    public GameObject partner_image;

    public TextMeshProUGUI lover_job;
    public TextMeshProUGUI lover_skill;



    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lover_job.SetText($"{thisPartner.name_text}");
        lover_skill.SetText($"{thisPartner.skill_text}\nเงินเดือน: {thisPartner.partner_salary.ToString("N0")} บาท");

        partner_information.SetActive(show_info);
        partner_image.SetActive(!show_info);
    }

    public void addLover()
    {
        player_stats.partner = thisPartner;
    }

    public void toggle_info()
    {
        show_info = !show_info;
    }
}
