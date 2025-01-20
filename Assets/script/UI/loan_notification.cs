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
        if(player.loan_debt > 0)
        {
            int loan = player.loan_debt;
            loan_panel.SetActive(true);
            loan_text.SetText($"You don't have enough money. You have to take loan of {loan} baht.");
        }
    }

    public void reset_panel()
    {
        player.loan_debt = 0;
    }
}
