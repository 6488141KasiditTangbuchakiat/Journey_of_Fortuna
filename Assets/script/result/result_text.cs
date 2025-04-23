using System.Collections;
using TMPro;
using UnityEngine;

public class result_text : MonoBehaviour
{
    public statistics player;

    public TextMeshProUGUI money;
    public TextMeshProUGUI reserve;
    public TextMeshProUGUI house;
    public TextMeshProUGUI car;
    public TextMeshProUGUI insur;
    public TextMeshProUGUI pfund;

    public GameObject rankS;
    public GameObject rankA;
    public GameObject rankB;
    public GameObject rankFail;

    public GameObject check1;
    public GameObject check2;
    public GameObject check3;
    public GameObject check4;
    public GameObject check5;
    public GameObject check6;


    public GameObject button;

    int counter = 0;
    string rank_txt;

    public int money_goal = 0;
    public int all_money = 0;
    int reserve_cap = 2;
    public int insurance_day_cap = 20;
    public int p_fund_cap = 50000;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(result_scoring());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator result_scoring()
    {
        yield return new WaitForSeconds(1.0f);
        money.SetText($"{player.money}");

        money_goal = player.myJob.all_expense();

        if (player.hasCar != null)
        {
            money_goal -= player.myJob.job_expense_travel;
        }

        if (player.hasHouse != null)
        {
            money_goal -= player.myJob.job_expense_housing;
        }

        money_goal = money_goal * 12 * 37;

        all_money = player.money + player.reserve_money;

        if (all_money >= money_goal)
        {
            counter++;

            check1.SetActive(true);
        }

        yield return new WaitForSeconds(0.5f);
        reserve.SetText($"{player.reserve_money}");
        if (player.reserve_threshold_reached >= reserve_cap)
        {
            counter++;

            check2.SetActive(true);
        }

        yield return new WaitForSeconds(0.5f);
        if (player.hasHouse != null)
        {
            house.SetText($"has house");
            counter++;

            check3.SetActive(true);
        }
        else
        {
            house.SetText($":'(");
        }



        yield return new WaitForSeconds(0.5f);
        if (player.hasCar != null)
        {
            car.SetText($"has car");
            counter++;

            check4.SetActive(true);
        }
        else
        {
            car.SetText($":'(");
        }


        yield return new WaitForSeconds(0.5f);
        insur.SetText($"{player.insurance_day_count}");
        if (player.insurance_day_count >= insurance_day_cap)
        {
            counter++;

            check5.SetActive(true);
        }

        yield return new WaitForSeconds(0.5f);
        pfund.SetText($"{player.p_fund}");

        yield return new WaitForSeconds(1.0f);

        if (player.p_fund >= p_fund_cap)
        {
            counter++;

            check6.SetActive(true);
        }

        if (counter == 6)
        {
            // rank S

            rankS.SetActive(true);
        }
        else if (counter >= 4)
        {
            // rank_ A

            rankA.SetActive(true);
        }
        else if (counter >= 2)
        {
            //rank B

            rankB.SetActive(true);
        }
        else
        {
            //rank fail

            rankFail.SetActive(true);
        }



        button.SetActive(true);
    }
}
