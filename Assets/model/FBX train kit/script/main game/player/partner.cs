using UnityEngine;

public class partner : MonoBehaviour
{
    public enum Job_type { Doctor, Lawyer, BusinessPerson, Technician, Engineer, Accountant, NurseryTeacher, Athlete, Chef, Banker }
    public Job_type partner_job;

    public int partner_salary = 0;

    public enum rarity { common, rare, very_rare }
    public rarity myRarity;

    public string name_text;
    public string skill_text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}
