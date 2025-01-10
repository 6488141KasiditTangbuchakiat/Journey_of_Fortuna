using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class greed_event_info : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    TextMeshProUGUI textmeshPro;
    public greed_card card;

    void Start()
    {
        textmeshPro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(card != null) {
            int num = card.moneyLost;
            string word = card.flavourText;
            textmeshPro.SetText($"{word}, You lost: {num}");
        }
    }
}
