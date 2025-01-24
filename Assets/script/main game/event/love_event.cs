using UnityEngine;

public class love_event : MonoBehaviour
{
    public GameObject big_panel;
    public GameObject event_partner;
    public GameObject event_partner2;
    public GameObject event_partner3;

    public GameObject event_child;


    public statistics player_stats;

    public partner_pool pool;
    public partner _partner;


    public lover_slot slot1;
    public lover_slot slot2;
    public lover_slot slot3;

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

        if (player_stats.love_level == 0)
        {
            print("fire partner");
            event_partner.SetActive(true);
            event_partner2.SetActive(false);
            event_partner3.SetActive(false);
            event_child.SetActive(false);


            slot1.thisPartner = pool.random_one_partner();
            slot2.thisPartner = pool.random_one_partner();
            slot3.thisPartner = pool.random_one_partner();

            player_stats.increase_love_level();

        }
        else
        {
            print("fire child");
            event_child.SetActive(true);
            event_partner.SetActive(false);
            event_partner2.SetActive(false);
            event_partner3.SetActive(false);

            player_stats.increase_love_level();
        }



    }
}
