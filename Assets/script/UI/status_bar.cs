using TMPro;
using UnityEngine;

public class status_bar : MonoBehaviour
{

    public statistics player;

    public TextMeshProUGUI job;
    public TextMeshProUGUI salary;
    public TextMeshProUGUI debt;
    public TextMeshProUGUI partner;
    public TextMeshProUGUI child;

    int childnum;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        childnum = player.love_level - 1;
        if(childnum < 0 )
        {
            childnum = 0;
        }

        job.SetText($"Job: {player.myJob.my_job}");
        salary.SetText($"Salary: {player.myJob.salary_on_green_tile}");
        debt.SetText($"House debt: {player.house_debt}\nCar debt: {player.car_debt}\nLoan: {player.loan_debt}");

        if(player.partner != null)
        {
            partner.SetText($"Partner: {player.partner.partner_job}");
        }
        else
        {
            partner.SetText($"Partner: None");
        }
        
        child.SetText($"Child: {childnum}");
    }
}
