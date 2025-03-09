using UnityEngine;

public class job : MonoBehaviour
{
    public string my_job;

    public int job_salary;
    public int job_raise = 0;
    public int job_expense;

    public int child_cost = 0;

    public string name_text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int real_salary()
    {
        return job_salary - job_expense;
    }
}
