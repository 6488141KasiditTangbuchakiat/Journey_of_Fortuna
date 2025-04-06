using TMPro;
using UnityEngine;

public class job_slot : MonoBehaviour
{
    public statistics player_stats;
    public job thisJob;

    public TextMeshProUGUI job_name;
    public TextMeshProUGUI job_salary;
    public TextMeshProUGUI job_expense;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //job_name.SetText($"{thisJob.my_job}");
        job_name.SetText($"{thisJob.name_text}");
        job_salary.SetText($"เงินเดือน: {thisJob.job_salary.ToString("N0")}");
        job_expense.SetText($"รายจ่าย: {thisJob.all_expense().ToString("N0")}");
    }
    
    public void addJob()
    {
        player_stats.myJob = thisJob;
        player_stats.reserve_money_max = thisJob.job_salary * 6;
    }
}
