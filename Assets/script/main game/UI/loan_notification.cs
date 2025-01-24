using TMPro;
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
            loan_text.SetText($"You don't have enough money. You have to take loan of {loan} baht.");
        }
    }

    public void reset_panel()
    {
        player.borrowed_money = 0;
    }
}
