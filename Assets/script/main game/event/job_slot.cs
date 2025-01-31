using TMPro;
using UnityEngine;

public class job_slot : MonoBehaviour
{
    public statistics player_stats;
    public job thisJob;

    public TextMeshProUGUI job_name;
    public TextMeshProUGUI job_salary;

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
        job_name.SetText($"{thisJob.my_job}");
        job_salary.SetText($"Salary: {thisJob.salary_on_green_tile}");
    }

    public void addJob()
    {
        player_stats.myJob = thisJob;
    }
}
