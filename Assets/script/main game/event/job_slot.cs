using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class job_slot : MonoBehaviour
{
    public statistics player_stats;
    public job thisJob;

    public bool show_info = false;
    public GameObject job_information;
    public GameObject job_image;

    public Image job_name;

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
        job_salary.SetText($"เงินเดือน: {thisJob.job_salary.ToString("N0")}");
        job_expense.SetText($"รายจ่าย: {thisJob.all_expense().ToString("N0")}");

        job_information.SetActive(show_info);
        job_image.SetActive(!show_info);

        job_name.sprite = Resources.Load<Sprite>($"job_name/{thisJob.my_job}");
    }

    public void addJob()
    {
        player_stats.myJob = thisJob;
        player_stats.reserve_money_max = thisJob.job_salary * 6;
    }

    public void toggle_info()
    {
        show_info = !show_info;
    }
}
