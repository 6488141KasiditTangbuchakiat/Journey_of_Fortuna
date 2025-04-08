using TMPro;
using UnityEngine;

public class status_bar : MonoBehaviour
{
    private SaveManager saveManager;

    public statistics player;

    public TextMeshProUGUI myname;
    public TextMeshProUGUI job;
    public TextMeshProUGUI salary;
    public TextMeshProUGUI debt;
    public TextMeshProUGUI debt2;
    public TextMeshProUGUI debt3;
    public TextMeshProUGUI partner;
    public TextMeshProUGUI child;

    int childnum;
    string p_name;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        saveManager = Object.FindFirstObjectByType<SaveManager>();
        SaveData loadedData = saveManager.LoadGame();

        if (loadedData != null)
        {
            p_name = loadedData.player_name;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        childnum = player.love_level - 1;
        if(childnum < 0 )
        {
            childnum = 0;
        }

        myname.SetText(p_name);
        job.SetText($"{player.myJob.name_text}");
        salary.SetText($"{player.myJob.job_salary}");
        debt.SetText($"{player.house_debt}");
        debt2.SetText($"{player.car_debt}");
        debt3.SetText($"{player.loan_debt}");

        if (player.partner != null)
        {
            partner.SetText($"{player.partner.name_text}");
        }
        else
        {
            partner.SetText($"เป็นโสด เหงาจังเลย");
        }
        
        child.SetText($"{childnum}");
    }
}
