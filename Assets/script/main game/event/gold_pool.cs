using System.Collections.Generic;
using UnityEngine;

public class gold_pool : MonoBehaviour
{
    public List<gold_card> cardList = new List<gold_card>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public gold_card random_one_gold()
    {
        // cut out the selected

        int card_all = cardList.Count;

        if (card_all > 0)
        {
            gold_card selected_card = null;

            int num = Random.Range(0, cardList.Count);
            selected_card = cardList[num];
            cardList.RemoveAt(num);

            return selected_card;
        }
        else
        {
            return null;
        }
    }
}
