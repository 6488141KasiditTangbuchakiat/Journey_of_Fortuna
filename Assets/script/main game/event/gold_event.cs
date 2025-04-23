using UnityEngine;

public class gold_event : MonoBehaviour
{
    public GameObject big_panel;
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;

    public gold_pool pool;

    public gold_slot slot1;
    public gold_slot slot2;
    public gold_slot slot3;

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

        /*
        slot1.thisCard = pool.random_one_gold();  
        slot2.thisCard = pool.random_one_gold();
        slot3.thisCard = pool.random_one_gold();
        */

        slot1.thisCard = pool.cardList[1];
        slot2.thisCard = pool.cardList[0];
        slot3.thisCard = pool.cardList[2];
    }

    public void shut()
    {
        big_panel.SetActive(false);
        panel1.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(false);
    }
}
