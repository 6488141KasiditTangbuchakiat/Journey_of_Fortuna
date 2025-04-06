using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class deck_mechanics : MonoBehaviour
{

    public List<card> deck = new List<card>();

    // example ---> greed/g
    // is folder "greed" and get files with prefix "g". so greed/g99.json will be read

    // this will be "greed"
    public string suffix_card_dir;

    // this will be "g"
    public string suffix_card_type;

    int custom_card_num = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (suffix_card_dir != null && suffix_card_dir != "")
        {
            string directory = Application.persistentDataPath + "/" + suffix_card_dir;

            //print(directory);

            string[] dirs = Directory.GetFiles(directory, $"{suffix_card_type}*");

            foreach (string dir in dirs)
            {
                //print(dir);

                string card_json = File.ReadAllText(dir);

                //print(card_json);

                if (suffix_card_type == "g" || suffix_card_type == "p" || suffix_card_type == "c" || suffix_card_type == "house" || suffix_card_type == "car")
                {
                    insert_greed(card_json, $"g_custom{custom_card_num}");
                }
                else if (suffix_card_type == "n")
                {
                    insert_news(card_json, $"n_custom{custom_card_num}");
                }
                else if (suffix_card_type == "o")
                {
                    insert_oppo(card_json, $"o_custom{custom_card_num}");
                }

                custom_card_num++;
            }
        }



    }

    // Update is called once per frame
    void Update()
    {

    }

    public card drawCard()
    {
        int num = Random.Range(0, deck.Count);

        return deck[num];
    }

    public void insert_greed(string card_json, string obj_name)
    {
        greed_card_json card = JsonUtility.FromJson<greed_card_json>(card_json);




        // create new card

        GameObject go = new GameObject(obj_name);

        go.AddComponent<greed_card>();

        greed_card new_card = go.GetComponent<greed_card>();

        new_card.flavourText = card.flavourText;
        new_card.moneyLost = card.moneyLost;
        new_card.reactionText = card.reactionText;

        new_card.reactionText_alt = card.reactionText_alt;
        new_card.energyLost = card.energyLost;
        new_card.moneyLost_alt = card.moneyLost_alt;

        new_card.option_count = card.option_count;

        deck.Add(new_card);
    }

    public void insert_news(string card_json, string obj_name)
    {
        news_card_json card = JsonUtility.FromJson<news_card_json>(card_json);




        // create new card

        GameObject go = new GameObject(obj_name);

        go.AddComponent<news_card>();

        news_card new_card = go.GetComponent<news_card>();

        new_card.stock_id = card.stock_id;
        new_card.stock_price = card.stock_price;
        new_card.is_inflation = card.is_inflation;

        new_card.flavourText = card.flavourText;

        new_card.reactionText = card.reactionText;

        deck.Add(new_card);
    }

    public void insert_oppo(string card_json, string obj_name)
    {
        oppo_card_json card = JsonUtility.FromJson<oppo_card_json>(card_json);

        // create new card

        GameObject go = new GameObject(obj_name);

        go.AddComponent<oppo_card>();

        oppo_card new_card = go.GetComponent<oppo_card>();

        new_card.flavourText = card.flavourText;
        new_card.option_count = card.option_count;
        
        // option 1

        new_card.buttonText1 = card.buttonText1;

        GameObject oppo1 = new GameObject(obj_name);
        oppo1.AddComponent<oppo_p2_card>();

        oppo_p2_card oppo1_card = oppo1.GetComponent<oppo_p2_card>();

        oppo1_card.text = card.text1;
        oppo1_card.reactionText = card.reactionText1;

        oppo1_card.money_gain = card.money_gain1;
        oppo1_card.money_loss = card.money_loss1;

        oppo1_card.energy_gain = card.energy_gain1;
        oppo1_card.energy_loss = card.energy_loss1;


        new_card.button = oppo1_card;


        // if 2 choices
        if (new_card.option_count > 1)
        {
            // option 2

            new_card.buttonText2 = card.buttonText2;

            GameObject oppo2 = new GameObject(obj_name);
            oppo2.AddComponent<oppo_p2_card>();

            oppo_p2_card oppo2_card = oppo2.GetComponent<oppo_p2_card>();

            oppo2_card.text = card.text2;
            oppo2_card.reactionText = card.reactionText2;

            oppo2_card.money_gain = card.money_gain2;
            oppo2_card.money_loss = card.money_loss2;

            oppo2_card.energy_gain = card.energy_gain2;
            oppo2_card.energy_loss = card.energy_loss2;


            new_card.button2 = oppo2_card;
        }

        deck.Add(new_card);
    }
}


[System.Serializable]
public class greed_card_json
{
    public string flavourText;
    public int moneyLost;
    public string reactionText;

    public string reactionText_alt;
    public int energyLost;
    public int moneyLost_alt;

    public int option_count;
}

[System.Serializable]
public class news_card_json
{
    public int stock_id;
    public int stock_price;
    public bool is_inflation;

    public string flavourText;

    public string reactionText;
}

[System.Serializable]
public class oppo_card_json
{
    // main card

    public string flavourText;
    public int option_count;

    public string buttonText1;
    public string buttonText2;

    // choice 1

    public string text1;
    public string reactionText1;

    public int money_gain1;
    public int money_loss1;

    public int energy_gain1;
    public int energy_loss1;

    // choice 2 - if choice num is 1 this is ignored

    public string text2;
    public string reactionText2;

    public int money_gain2;
    public int money_loss2;

    public int energy_gain2;
    public int energy_loss2;
}
