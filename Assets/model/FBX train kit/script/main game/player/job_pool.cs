using System.Collections.Generic;
using UnityEngine;

public class job_pool : MonoBehaviour
{
    public List<job> jobList_veryRare = new List<job>();
    public List<job> jobList_rare = new List<job>();
    public List<job> jobList_common = new List<job>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public job random_one_job()
    {
        // cut out the selected

        int job_all = jobList_veryRare.Count + jobList_rare.Count + jobList_common.Count;

        if (job_all > 0)
        {
            int chance = Random.Range(1, 100);
            job selected_job = null;

            print(chance);

            if (chance >= 0 && chance < 5 && jobList_veryRare.Count > 0)
            {
                // very rare job

                print("very rare job");

                int num = Random.Range(0, jobList_veryRare.Count);
                selected_job = jobList_veryRare[num];
                jobList_veryRare.RemoveAt(num);

            }
            else if (chance >= 5 && chance < 30 && jobList_rare.Count > 0)
            {
                // rare job

                print("rare job");

                int num = Random.Range(0, jobList_rare.Count);
                selected_job = jobList_rare[num];
                jobList_rare.RemoveAt(num);

            }
            else if (chance >= 30 && chance < 100 && jobList_common.Count > 0)
            {
                //common job

                print("common job");

                int num = Random.Range(0, jobList_common.Count);
                selected_job = jobList_common[num];
                jobList_common.RemoveAt(num);
            }
            else
            {
                // pity system
                if (jobList_common.Count > 0)
                {
                    int num = Random.Range(0, jobList_common.Count);
                    selected_job = jobList_common[num];
                    jobList_common.RemoveAt(num);

                }
                else if (jobList_rare.Count > 0)
                {
                    int num = Random.Range(0, jobList_rare.Count);
                    selected_job = jobList_rare[num];
                    jobList_rare.RemoveAt(num);

                }
                else if (jobList_veryRare.Count > 0)
                {
                    int num = Random.Range(0, jobList_veryRare.Count);
                    selected_job = jobList_veryRare[num];
                    jobList_veryRare.RemoveAt(num);

                }
            }

            return selected_job;
        }



        return null;

    }
}
