﻿using TMPro;
using UnityEngine;

public class loan_notification : MonoBehaviour
{
    public GameObject loan_panel;
    public TextMeshProUGUI loan_text;

    public statistics player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(player.borrowed_money > 0)
        {
            int loan = player.borrowed_money;
            loan_panel.SetActive(true);
            loan_text.SetText($"ตอนนี้คุณเป็นหนี้อยู่ {loan} บาท อย่าลืมรีบใช้หนี้ให้เรียบร้อยนะ");
        }
    }

    public void reset_panel()
    {
        player.borrowed_money = 0;
    }
}
