using UnityEngine;

public class job_event : MonoBehaviour
{
    public GameObject big_panel;
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;

    public statistics player;

    public job_pool pool;
    public job _job;


    public job_slot slot1;
    public job_slot slot2;
    public job_slot slot3;

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
        big_panel.SetActive(true);
        panel1.SetActive(true);
        panel2.SetActive(false);
        panel3.SetActive(false);


        slot1.thisJob = pool.random_one_job();
        slot2.thisJob = pool.random_one_job();
        slot3.thisJob = pool.random_one_job();

    }
}
